using System;
using System.Runtime.CompilerServices;

namespace Fingerprint.ServerSdk.Test
{
    internal static class TestAssemblyInitializer
    {
        /// <summary>
        /// Host.CreateDefaultBuilder watches appsettings.json by default, creating one inotify instance per host.
        /// Tests build many hosts, which exhausts the Linux limit (128) on CI runners.
        /// </summary>
        [ModuleInitializer]
        internal static void DisableConfigReloadOnChange() =>
            Environment.SetEnvironmentVariable("DOTNET_hostBuilder__reloadConfigOnChange", "false");
    }
}
