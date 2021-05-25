using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Warehouse.Infrastructure;
using Cella.Models;
using Cella.Infrastructure;

namespace WarehouseCrm.Infrastructure.Modules
{
    public class ModuleConfigurationManager : IModuleConfigurationManager
    {
        public static readonly string ModulesFilename = "modules.json";

        public IEnumerable<ModuleInfo> GetModules()
        {
            var modulesPath = Path.Combine(GlobalConfiguration.ContentRootPath, ModulesFilename);
            using var reader = new StreamReader(modulesPath);
            string content = reader.ReadToEnd();
            dynamic modulesData = JsonConvert.DeserializeObject(content);
            foreach (var module in modulesData)
            {
                yield return new ModuleInfo
                {
                    Id = module.id,
                    Name=module.name,
                    Version = Version.Parse(module.version.ToString()),
                    IsBundledWithHost = module.isBundledWithHost,
                    isEnabled = module.isEnabled,
                    Thumbnail = module.thumbnail,
                    Type = module.type,
                    Order = module.order

                };
            }
        }
    }
}
