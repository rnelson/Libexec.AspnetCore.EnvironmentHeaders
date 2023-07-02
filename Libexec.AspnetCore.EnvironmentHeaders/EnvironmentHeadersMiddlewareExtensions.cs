using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libexec.AspnetCore.EnvironmentHeaders;

/// <summary>
/// Class used to add the middleware to your ASP.NET Core application.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class EnvironmentHeadersMiddlewareExtensions
{
    /// <summary>
    /// Configure the environment headers middleware in Startup.ConfigureServices().
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configAction">Configuration action.</param>
    /// <returns></returns>
    public static IServiceCollection AddEnvironmentHeaders(this IServiceCollection services,
        Action<EnvironmentHeadersConfiguration> configAction = null)
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetService<IConfiguration>();

        var config = new EnvironmentHeadersConfiguration();
        configuration.Bind(EnvironmentHeadersConfiguration.ConfigurationKey, config);
        EnvironmentHeadersConfiguration.Current = config;

        if (config.EnvironmentHeadersEnabled)
            configAction?.Invoke(config);

        return services;
    }

    /// <summary>
    /// Add the <see cref="EnvironmentHeadersMiddleware"/> in Startup.Configure().
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseEnvironmentHeaders(this IApplicationBuilder builder)
    {
        var config = EnvironmentHeadersConfiguration.Current;

        if (config.EnvironmentHeadersEnabled)
            builder.UseMiddleware<EnvironmentHeadersMiddleware>();

        return builder;
    }
}