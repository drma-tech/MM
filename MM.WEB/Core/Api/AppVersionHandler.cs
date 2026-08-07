namespace MM.WEB.Core.Api
{
    public sealed class AppVersionHandler() : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("X-App-Version");

            request.Headers.Add("X-App-Version", AppStateStatic.Version);

            if (request.RequestUri?.Host.StartsWith("www.", StringComparison.OrdinalIgnoreCase) == true)
            {
                throw new UnhandledException("This domain has been deactivated. If you are accessing via an app (Windows, Android, Apple, etc.), please update it. If using a browser, please access the site without the 'www'.");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}