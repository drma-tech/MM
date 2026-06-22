using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.API.Core.Models;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Safety;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.API.Functions;

public class VerificationFunction(CosmosRepository repo, CosmosSafetyRepository repoSafety, StorageHelper storageHelper, IHttpClientFactory factory)
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

    [Function("GetSafetyGalleryPhoto")]
    public async Task<HttpResponseData> GetSafetyGalleryPhoto(
    [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "safety/get-photo-gallery")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken) ?? throw new NotificationException("user not available");
        var safety = await repoSafety.Get<SafetyModel>(userId, cancellationToken);

        using var faceStream = await storageHelper.GetSafetyPhoto(SafetyType.Gallery, safety?.GalleryPhotoId, cancellationToken);

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "image/jpeg");
        if (faceStream != null) await faceStream.CopyToAsync(response.Body, cancellationToken);

        return response;
    }

    [Function("CreateVerificationSession")]
    public async Task<string> CreateVerificationSession(
      [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "didit/create-verification-session")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken) ?? throw new NotificationException("user not available");
        var ip = req.GetUserIP(true);
        var url = req.GetQueryParameters()["url"] ?? throw new NotificationException("callback url not available");
        var email = req.GetQueryParameters()["email"];

        // Cria payload da sessão
        var sessionRequest = new
        {
            workflow_id = ApiStartup.Configurations.Didit?.WorkflowId,
            vendor_data = userId,
            callback = url,
            contact_details = new { email }
        };

        //todo: implement: portrait_image

        using var client = factory.CreateClient();
        client.DefaultRequestHeaders.Add("x-api-key", ApiStartup.Configurations.Didit?.ApiKey);

        var response = await client.PostAsJsonAsync("https://verification.didit.me/v3/session/", sessionRequest, cancellationToken);
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken: cancellationToken);
        var verificationUrl = data.GetProperty("url").GetString() ?? throw new UnhandledException("url missing");

        var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("principal null");

        principal.Events.Add(new Event("Didit", $"Session created with URL = {verificationUrl}", ip));

        await repo.UpsertItemAsync(principal, cancellationToken);

        return verificationUrl;
    }

    [Function("PostDiditWebhook")]
    public async Task<HttpResponseData> PostDiditWebhook(
      [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "public/didit/webhook")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var ip = req.GetUserIP(true);

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        await response.WriteStringAsync("ok", cancellationToken);

        var bodyRaw = await new StreamReader(req.Body).ReadToEndAsync(cancellationToken);
        using var document = JsonDocument.Parse(bodyRaw);
        var jsonBody = document.RootElement;

        // Headers (case-insensitive in Azure Functions, but keep exact names)
        var signature = req.Headers.TryGetValues("X-Signature-V2", out var sigValues) ? sigValues.FirstOrDefault() : null;
        var timestamp = req.Headers.TryGetValues("X-Timestamp", out var tsValues) ? tsValues.FirstOrDefault() : null;

        if (!DiditVerify.VerifySignatureV2(jsonBody, signature, timestamp, ApiStartup.Configurations.Didit?.SecretKey))
        {
            var unauthorized = req.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            await unauthorized.WriteStringAsync("invalid signature", cancellationToken);
            return unauthorized;
        }

        var payload = JsonSerializer.Deserialize<DiditResponse>(bodyRaw, JsonSerializerOptions) ?? throw new UnhandledException("invalid payload");
        var userId = payload.vendor_data ?? throw new UnhandledException("vendor_data missing");

        if (payload.status == "Not Started") return response;
        if (payload.status == "In Progress") return response;

        var principalTask = repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);
        var validationTask = repo.Get<ValidationModel>(DocumentType.Validation, userId, cancellationToken);

        await Task.WhenAll(principalTask, validationTask);

        var principal = principalTask.Result ?? throw new UnhandledException("principal null");
        var validation = validationTask.Result ?? throw new UnhandledException("validation null");

        principal.Events.Add(new Event("Didit (Webhooks)", $"Status = {payload.status} for SessionId = {payload.session_id}", ip));

        if (payload.status == "Approved")
        {
            validation.Identity = true;

            //delete session (required by privacy laws)
            var sessionUrl = $"https://verification.didit.me/v3/session/{payload.session_id}/delete/";
            using var sessionRequest = new HttpRequestMessage(HttpMethod.Delete, sessionUrl);

            sessionRequest.Headers.Add("x-api-key", ApiStartup.Configurations.Didit?.ApiKey);

            using var http = factory.CreateClient();
            await http.SendAsync(sessionRequest, cancellationToken);
        }
        else
        {
            validation.Identity = false;
            req.LogWarning($"verification not succceded (user-id: {userId}): status={payload.status}");
        }

        var user = payload.decision?.id_verifications?.LastOrDefault();
        SafetyModel? safety = null;

        if (user == null) throw new UnhandledException("user not found");
        if (user.nationality == null) throw new UnhandledException("nationality not found");
        if (user.date_of_birth == null) throw new UnhandledException("date_of_birth not found");
        if (user.full_name == null) throw new UnhandledException("full_name not found");

        safety = await repoSafety.Get<SafetyModel>(userId, cancellationToken);
        if (safety == null)
        {
            safety = new SafetyModel();
            safety.SetIds(userId);
        }

        safety.provider = "didit";
        safety.session_id = payload.session_id;
        safety.workflow_id = payload.workflow_id;

        safety.ComposeHash(user.nationality, user.date_of_birth, user.full_name);

        var ipAnalyse = payload?.decision?.ip_analyses?.LastOrDefault();

        if (ipAnalyse != null)
        {
            safety.ip_address = ipAnalyse.ip_address;
        }

        await Task.WhenAll(
            repo.UpsertItemAsync(principal, cancellationToken),
            repo.UpsertItemAsync(validation, cancellationToken),
            repoSafety.UpsertItemAsync(safety, cancellationToken)
        );

        return response;
    }
}