using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.API.Core.Models;
using MM.Shared.Models.Auth;
using System.Net.Http.Json;
using System.Text.Json;

namespace MM.API.Functions;

public class VerificationFunction(CosmosRepository repo, IHttpClientFactory factory)
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

        using var client = new HttpClient();
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
        var bodyRaw = await new StreamReader(req.Body).ReadToEndAsync(cancellationToken);
        var jsonBody = JsonDocument.Parse(bodyRaw).RootElement;

        // Headers (case-insensitive in Azure Functions, but keep exact names)
        var signature = req.Headers.TryGetValues("X-Signature-V2", out var sigValues) ? sigValues.FirstOrDefault() : null;
        var timestamp = req.Headers.TryGetValues("X-Timestamp", out var tsValues) ? tsValues.FirstOrDefault() : null;

        if (!DiditVerify.VerifySignatureV2(jsonBody, signature, timestamp, ApiStartup.Configurations.Didit?.SecretKey))
        {
            var unauthorized = req.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            await unauthorized.WriteStringAsync("invalid signature", cancellationToken);
            return unauthorized;
        }

        var payload = JsonSerializer.Deserialize<DiditResponse>(bodyRaw, JsonSerializerOptions);

        // TODO: handle events properly
        Console.WriteLine($"Session: {payload?.session_id} Status: {payload?.status}");

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        await response.WriteStringAsync("ok", cancellationToken);

        return response;
    }
}