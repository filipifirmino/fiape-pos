using System;
using System.Diagnostics;

namespace Marketplace.Catalog.Api.Middlewares;

public class RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var stopwatch = Stopwatch.StartNew();
         
        httpContext.Response.OnStarting(() =>
        {
            stopwatch.Stop();
            var elapsedMs = stopwatch.ElapsedMilliseconds;

            httpContext.Response.Headers["X-Response-Time-ms"] = elapsedMs.ToString();
            logger.LogInformation("Request took {ElapsedMs} ms", elapsedMs);

            return Task.CompletedTask;
        });

        await next(httpContext);
    }
}
