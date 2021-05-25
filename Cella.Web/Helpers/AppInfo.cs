using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace Warehouse.Web.Helpers
{
    public static class AppInfo
    {

        public static string VersionInfo()
        {


            var framework = Assembly
  .GetEntryAssembly()?
  .GetCustomAttribute<TargetFrameworkAttribute>()?
  .FrameworkName;

            var stats = new
            {
                OsPlatform = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
                AspDotnetVersion = framework
            };

            return stats.AspDotnetVersion;
        }


    }
}
