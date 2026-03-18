using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Models;
using System.Text.Json;

namespace MM.API.Functions;

public class VerificationFunction
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

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