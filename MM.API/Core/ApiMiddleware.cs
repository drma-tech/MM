using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using System.Diagnostics;
using System.Net;

namespace MM.API.Core;

internal sealed class ApiMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var req = await context.GetHttpRequestDataAsync();
        var sw = Stopwatch.StartNew();

        try
        {
            if (req is null)
            {
                await next(context);
                return;
            }

            //req.LogWarning($"Url: {req.Url}");
            //req.LogWarning($"Url.Host: {req.Url.Host}");
            //req.LogWarning($"Url.Authority: {req.Url.Authority}");

            //if (req.Headers.TryGetValues("Host", out var hostHeaders))
            //{
            //    req.LogWarning($"Host header: {string.Join(",", hostHeaders)}");
            //}

            //if (req.Headers.TryGetValues("X-Forwarded-Host", out var forwardedHosts))
            //{
            //    req.LogWarning($"X-Forwarded-Host: {string.Join(",", forwardedHosts)}");
            //}

            //if (req.Headers.TryGetValues("X-Original-Host", out var originalHosts))
            //{
            //    req.LogWarning($"X-Original-Host: {string.Join(",", originalHosts)}");
            //}

            //if (req.Headers.TryGetValues("Forwarded", out var forwarded))
            //{
            //    req.LogWarning($"Forwarded: {string.Join(",", forwarded)}");
            //}

            //if (req.Headers.TryGetValues("Origin", out var origins))
            //{
            //    req.LogWarning($"Origin: {string.Join(",", origins)}");
            //}

            //if (req.Headers.TryGetValues("Referer", out var referers))
            //{
            //    req.LogWarning($"Referer: {string.Join(",", referers)}");
            //}

            foreach (var header in req.Headers)
            {
                SentrySdk.CaptureMessage($"{header.Key}: {string.Join(",", header.Value)}", SentryLevel.Warning);
            }

            if (req.Url.Host.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
            {
                await context.SetHttpResponseStatusCode(HttpStatusCode.Gone, Shared.Translations.Validation.Validations.DomainDeactivated);

                return;
            }

            if (req.Url.AbsolutePath.Contains("webhook", StringComparison.OrdinalIgnoreCase))
            {
                await next(context);
                return;
            }

            if (req.Url.AbsolutePath.Contains("job", StringComparison.OrdinalIgnoreCase))
            {
                await next(context);
                return;
            }

            var version = req.Headers.TryGetValues("X-App-Version", out var values) ? values.FirstOrDefault() : null;

            if (HttpRequestDataExtensions.IsOutdated(version))
            {
                await context.SetHttpResponseStatusCode(
                    HttpStatusCode.UpgradeRequired,
                    string.Format(System.Globalization.CultureInfo.CurrentCulture, Shared.Translations.Validation.Validations.OutdatedVersion, version ?? "error"));
                return;
            }

            await next(context);
        }
        catch (CosmosException ex)
        {
            req?.LogError(ex);
            await context.SetHttpResponseStatusCode(HttpStatusCode.InternalServerError, "Invocation failed!");
        }
        catch (NotificationException ex)
        {
            await context.SetHttpResponseStatusCode(HttpStatusCode.BadRequest, ex.Message);
        }
        catch (CosmosOperationCanceledException)
        {
            // ignored
        }
        catch (TaskCanceledException)
        {
            // ignored
        }
        catch (OperationCanceledException)
        {
            // ignored
        }
        catch (ObjectDisposedException)
        {
            // ignored
        }
        catch (Exception ex)
        {
            req?.LogError(ex);

            if (string.Equals(ex.Message, "Not Found", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (string.Equals(ex.Message, "Bad Gateway", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (string.Equals(ex.Message, "Too Many Requests", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            await context.SetHttpResponseStatusCode(HttpStatusCode.InternalServerError, "This request could not be processed.");
        }
        finally
        {
            sw.Stop();
            if (sw.ElapsedMilliseconds > 7000)
            {
                req?.LogWarning($"Executed in {sw.Elapsed}");
            }
        }
    }
}