using System.Text;
using System.Text.Json;

namespace MM.API.Core
{
    public class ZeptoMailClient(string apiKey)
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _apiKey = apiKey;

        public async Task SendOtpEmail(string toEmail, string reference, string? otp, CancellationToken cancellationToken)
        {
            var payload = new
            {
                from = new { address = "noreply@drma-tech.com", name = "DRMA Tech" },
                to = new[] { new { email_address = new { address = toEmail, name = "" } } },
                subject = "DRMA Tech - Your OTP Code",
                htmlbody = $"<p>Your verification code is <b>{otp}</b></p>",
                client_reference = reference
            };

            var json = JsonSerializer.Serialize(payload);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.zeptomail.com/v1.1/email");

            request.Headers.Add("Authorization", _apiKey);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request, cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new NotificationException($"ZeptoMail error: {response.StatusCode} - {body}");
            }
        }
    }
}