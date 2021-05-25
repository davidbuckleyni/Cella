using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Razor;
using System.IO;
using WarehouseCrm.Infrastructure;
using Cella.Infrastructure;

namespace WarehouseCrm.Web.Helpers
{
    public static class ThemeViewExtensions
    {

        public static string GetViewPath(string controller, string action,string themeName)
        {
            var themeFolderWWWroot = new DirectoryInfo(Path.Combine(GlobalConfiguration.WebRootPath, "themes", themeName));
            string path = GlobalConfiguration.WebRootPath;

            ViewResult result = new ViewResult();
            result.ViewName = $"/Themes/{themeName}/Views/{controller}/{action}" + ".cshtml";
           
            var viewResult = $"/Themes/{themeName}/Views/{controller}/{action}" + ".cshtml";

            return viewResult;
        }
    }
}
