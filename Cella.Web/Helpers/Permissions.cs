using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Web.Helpers {
    public static class PermissionsCRUD {
        public static class StockItems
        {
            public const string View = "Permissions.StockItems.View";
            public const string Create = "Permissions.StockItems.Create";
            public const string Edit = "Permissions.StockItems.Edit";
            public const string Delete = "Permissions.StockItems.Delete";
        }

    }
}
