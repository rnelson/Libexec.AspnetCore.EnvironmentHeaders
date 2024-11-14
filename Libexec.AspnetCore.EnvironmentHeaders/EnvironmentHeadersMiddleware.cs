using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Libexec.AspnetCore.EnvironmentHeaders;

/// <summary>
/// The Environment Headers middleware adds headers to responses
/// that provide information about the server the request was handled
/// by.
/// </summary>
/// <remarks>
/// This may include sensitive data. You may want to only load this
/// middleware in development mode, or run the application behind
/// something that strips the headers out before being sent to the
/// end user.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class EnvironmentHeadersMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="EnvironmentHeadersMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next <see cref="RequestDelegate"/> to use.</param>
    public EnvironmentHeadersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var config = EnvironmentHeadersConfiguration.Current;
        if (!config.EnvironmentHeadersEnabled)
        {
            await _next(context);
            return;
        }

        await HandleHeaderInjection(context);
    }

    private async Task HandleHeaderInjection(HttpContext context)
    {
        var headers = EnvironmentHeaders.BuildHeaderDictionary().ToArray();
        foreach (var (key, value) in headers)
            context.Response.Headers[key] = value;

        await _next(context);
    }
}