using System.Collections.Generic;
using Cella.Models;

namespace WarehouseCrm.Infrastructure.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
    }
}