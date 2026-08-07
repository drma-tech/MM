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
                throw new UnhandledException(MM.Shared.Translations.Validation.Validations.DomainDeactivated);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}