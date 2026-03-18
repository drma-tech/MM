using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.API.Core.Models;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Verification;
using System.Net.Http.Json;
using System.Text.Json;

namespace MM.API.Functions;

public class VerificationFunction(CosmosRepository repo, CosmosIdsRepository repoIds, IHttpClientFactory factory)
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

    [Function("CreateVerificationSession")]
    public async Task<string> CreateVerificationSession(
      [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "didit/create-verification-session")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken) ?? throw new NotificationException("user not available");
        var ip = req.GetUserIP(true);
        var url = req.GetQueryParameters()["url"];

        // Cria payload da sessão
        var sessionRequest = new
        {
            workflow_id = ApiStartup.Configurations.Didit?.WorkflowId,
            vendor_data = userId,
            callback = url
        };

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

        var principalTask = repo.Get<AuthPrincipal>(DocumentType.Principal, payload.vendor_data, cancellationToken);
        var validationTask = repo.Get<ValidationModel>(DocumentType.Validation, payload.vendor_data, cancellationToken);

        await Task.WhenAll(principalTask, validationTask);

        var principal = principalTask.Result ?? throw new UnhandledException("principal null");
        var validation = validationTask.Result ?? throw new UnhandledException("validation null");

        principal.Events.Add(new Event("Didit (Webhooks)", $"Status = {payload.status} for SessionId = {payload.session_id}", ip));

        const string approved = "Approved";

        var decisionStatus = payload.decision?.status == approved;
        var idStatus = payload.decision?.id_verifications?.LastOrDefault()?.status == approved;
        var ipStatus = payload.decision?.ip_analyses?.LastOrDefault()?.status == approved;
        var livenessStatus = payload.decision?.liveness_checks?.LastOrDefault()?.status == approved;
        var reviewStatus = payload.decision?.reviews?.LastOrDefault()?.new_status == approved || payload.decision?.reviews == null || payload.decision.reviews.Empty();

        var isApproved = decisionStatus && idStatus && ipStatus && livenessStatus && reviewStatus;

        if (isApproved)
        {
            validation.Identity = isApproved;
        }
        else
        {
            req.LogWarning($"verification not succceded (user-id: {payload.vendor_data}): decision={decisionStatus}, id_verifications={idStatus}, ip_analyses={ipStatus}, liveness_checks={livenessStatus}, reviews={reviewStatus}");
        }

        var user = payload.decision?.id_verifications?.LastOrDefault() ?? throw new UnhandledException("id_verifications not available");

        var id = new IdModel
        {
            session_id = payload.session_id,
            workflow_id = payload.workflow_id,
            full_name = user.full_name,
            gender = user.gender,
            issuing_state = user.issuing_state,
            date_of_birth = user.date_of_birth,
            date_of_issue = user.date_of_issue,
            document_number = user.document_number,
            document_type = user.document_type,
            nationality = user.nationality,
            place_of_birth = user.place_of_birth
        };

        id.SetIds(payload.vendor_data!);

        await Task.WhenAll(
            repo.UpsertItemAsync(principal, cancellationToken),
            repo.UpsertItemAsync(validation, cancellationToken),
            repoIds.CreateItemAsync(id, cancellationToken)
        );

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        await response.WriteStringAsync("ok", cancellationToken);

        return response;
    }
}