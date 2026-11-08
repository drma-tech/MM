using System.Text;
using System.Text.Json;

namespace MM.API.Core
{
    public class ZeptoMailClient(IHttpClientFactory factory, string apiKey)
    {
        private const string _uri = "https://api.zeptomail.com/v1.1/email/template";
        private const string domain = "modern-matchmaker";
        private const string appName = "Modern Matchmaker";
        private const string appSubtitle = "Find a compatible partner through Matchmaking";
        private static string noreplyEmail => $"noreply@{domain}.com";
        private static string year => DateTime.Now.Year.ToString(System.Globalization.CultureInfo.InvariantCulture);

        public async Task SendWelcomeTemplate(string user_id, string address, string? name, CancellationToken cancellationToken)
        {
            name = name.NotEmpty() ? name : address.Split("@")[0];

            var payload = new
            {
                template_alias = "welcome",
                from = new { address = noreplyEmail, name = appName },
                to = new[] { new { email_address = new { address, name } } },
                merge_info = new
                {
                    product_title = appName,
                    product_subtitle = appSubtitle,
                    domain,
                    year,
                    user_name = name,
                },
                client_reference = user_id,
            };

            var json = JsonSerializer.Serialize(payload);

            var request = new HttpRequestMessage(HttpMethod.Post, _uri);

            request.Headers.Add("Authorization", apiKey);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = factory.CreateClient();
            var response = await client.SendAsync(request, cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new NotificationException($"ZeptoMail error: {response.StatusCode} - {body}");
            }
        }

        public async Task SendGoPublicEmail(string toEmail, string reference, CancellationToken cancellationToken)
        {
            //var payload = new
            //{
            //    from = new { address = noreplyEmail, name = "DRMA Tech" },
            //    to = new[] { new { email_address = new { address = toEmail, name = "" } } },
            //    subject = $"{appName} - Complete your profile and go public",
            //    htmlbody = @$"
            //     <!DOCTYPE html>
            //    <html lang=""en"">
            //    <head>
            //        <meta charset=""utf-8"">
            //        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            //        <style>
            //            {CssBase}
            //            {CssSections}
            //            {CssQuickLinks}
            //            {CssProducts}
            //        </style>
            //    </head>
            //    <body>
            //        <div class=""email-wrapper"">
            //            <div class=""email-container"">

            //                <!-- HEADER -->
            //                {HtmlHeader}

            //                <!-- CONTENT -->
            //                <div class=""email-content"">
            //                    <h2 class=""email-title"">
            //                        You're just a few steps away from going live
            //                    </h2>

            //                    <p class=""email-text"">
            //                        A while ago, you started creating your profile on
            //                        <span class=""email-highlight"">{appName}</span>.
            //                    </p>

            //                    <p class=""email-text"">
            //                        Your profile is currently in <span class=""email-highlight"">Private Mode</span>, which means it is not visible to other members yet.
            //                    </p>

            //                    <p class=""email-text"">
            //                        To publish your profile, you'll need to complete the remaining setup steps, including your profile information, preferences, photos, and verification requirements.
            //                    </p>

            //                    <p class=""email-text"">
            //                        Once all the steps are completed, your profile will become public and visible to other members of the platform.
            //                    </p>

            //                    <a href=""https://{domain}.com/default/profile"" class=""email-button"" target=""_blank"">
            //                        Complete Your Profile
            //                    </a>

            //                    <hr class=""email-divider"">
            //                    <div class=""email-support"">
            //                        Questions? Contact
            //                        <a href=""mailto:{supportEmail}"">
            //                            {supportEmail}
            //                        </a>
            //                    </div>
            //                    <div class=""email-signature"">
            //                        <small>Have a great day,</small>
            //                        <strong>Team DRMA Tech</strong>
            //                    </div>
            //                </div>

            //                <!-- FOOTER -->
            //                {HtmlFooter}
            //            </div>
            //        </div>
            //    </body>
            //    </html>",
            //    client_reference = reference,
            //};

            //var json = JsonSerializer.Serialize(payload);

            //var request = new HttpRequestMessage(HttpMethod.Post, _uri);

            //request.Headers.Add("Authorization", _apiKey);
            //request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            //using var client = factory.CreateClient();
            //var response = await client.SendAsync(request, cancellationToken);

            //var body = await response.Content.ReadAsStringAsync(cancellationToken);

            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new NotificationException($"ZeptoMail error: {response.StatusCode} - {body}");
            //}
        }

        public async Task SendGoPublicAgainEmail(string toEmail, string reference, CancellationToken cancellationToken)
        {
            //var payload = new
            //{
            //    from = new { address = noreplyEmail, name = "DRMA Tech" },
            //    to = new[] { new { email_address = new { address = toEmail, name = "" } } },
            //    subject = $"{appName} - Your profile requires attention",
            //    htmlbody = @$"
            //     <!DOCTYPE html>
            //    <html lang=""en"">
            //    <head>
            //        <meta charset=""utf-8"">
            //        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            //        <style>
            //            {CssBase}
            //            {CssSections}
            //            {CssQuickLinks}
            //            {CssProducts}
            //        </style>
            //    </head>
            //    <body>
            //        <div class=""email-wrapper"">
            //            <div class=""email-container"">

            //                <!-- HEADER -->
            //                {HtmlHeader}

            //                <!-- CONTENT -->
            //                <div class=""email-content"">
            //                    <h2 class=""email-title"">
            //                        Your profile needs a quick review
            //                    </h2>

            //                    <p class=""email-text"">
            //                        Thank you for being part of <span class=""email-highlight"">{appName}</span>.
            //                    </p>

            //                    <p class=""email-text"">
            //                        Your profile was previously public and visible to other members, but it has been temporarily moved to <span class=""email-highlight"">Private Mode</span>.
            //                    </p>

            //                    <p class=""email-text"">
            //                        This may be due to an internal profile review or updates to our platform requirements.
            //                    </p>

            //                    <p class=""email-text"">
            //                        Visit your profile to review any information, photos, preferences, or verification details that may require attention.
            //                    </p>

            //                    <p class=""email-text"">
            //                        Once all requirements are met, you can return to Public Mode and continue connecting with other members.
            //                    </p>

            //                    <a href=""https://{domain}.com/default/profile"" class=""email-button"" target=""_blank"">
            //                        Review Your Profile
            //                    </a>
            //                    <hr class=""email-divider"">
            //                    <div class=""email-support"">
            //                        Questions? Contact
            //                        <a href=""mailto:{supportEmail}"">
            //                            {supportEmail}
            //                        </a>
            //                    </div>
            //                    <div class=""email-signature"">
            //                        <small>Have a great day,</small>
            //                        <strong>Team DRMA Tech</strong>
            //                    </div>
            //                </div>

            //                <!-- FOOTER -->
            //                {HtmlFooter}
            //            </div>
            //        </div>
            //    </body>
            //    </html>",
            //    client_reference = reference,
            //};

            //var json = JsonSerializer.Serialize(payload);

            //var request = new HttpRequestMessage(HttpMethod.Post, _uri);

            //request.Headers.Add("Authorization", _apiKey);
            //request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            //using var client = factory.CreateClient();
            //var response = await client.SendAsync(request, cancellationToken);

            //var body = await response.Content.ReadAsStringAsync(cancellationToken);

            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new NotificationException($"ZeptoMail error: {response.StatusCode} - {body}");
            //}
        }
    }
}
