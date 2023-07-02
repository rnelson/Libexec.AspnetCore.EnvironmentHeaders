using System;
using System.Collections.Generic;

namespace Libexec.AspnetCore.EnvironmentHeaders;

internal static class EnvironmentHeaders
{
    internal static IDictionary<string, string> BuildHeaderDictionary()
    {
        const string prefix = "X-EnvHeaders";

        var result = new Dictionary<string, string>
        {
            {$"{prefix}-ServerName", Environment.MachineName},
            {$"{prefix}-RunningAs", $"{Environment.UserDomainName}\\{Environment.UserName}"},
            {$"{prefix}-CurrentDirectory", Environment.CurrentDirectory},
            {$"{prefix}-Command", Environment.CommandLine},
            {$"{prefix}-Version-OS", Environment.OSVersion.ToString()},
            {$"{prefix}-Version-Runtime", Environment.Version.ToString()}
        };

        return result;
    }
}