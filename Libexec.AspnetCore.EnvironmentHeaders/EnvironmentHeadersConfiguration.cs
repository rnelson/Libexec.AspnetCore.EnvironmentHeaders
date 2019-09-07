namespace Libexec.AspnetCore.EnvironmentHeaders
{
    public class EnvironmentHeadersConfiguration
    {
        /// <summary>
        /// Gets the name used to track this configuration.
        /// </summary>
        internal static string ConfigurationKey { get; } = "EnvironmentHeaders";

        /// <summary>
        /// Current configuration instance used by the <see cref="EnvironmentHeadersMiddleware"/>.
        /// </summary>
        public static EnvironmentHeadersConfiguration Current { get; set; }

        /// <summary>
        /// Determines whether or not the <see cref="EnvironmentHeadersMiddleware"/> is enabled.
        /// </summary>
        public bool EnvironmentHeadersEnabled { get; set; } = true;
    }
}
