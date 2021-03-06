#pragma checksum "D:\GitMaster\Cella\Cella.Web\Views\Admin\EditUserPermissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2193a8dd97ac3e5f46c66ee2b0d82022d2c04c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditUserPermissions), @"mvc.1.0.view", @"/Views/Admin/EditUserPermissions.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using Cella.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using SharedResourceLib.Lng;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using Cella.BL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using static Microsoft.AspNetCore.Mvc.Razor.RazorPage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2193a8dd97ac3e5f46c66ee2b0d82022d2c04c0", @"/Views/Admin/EditUserPermissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04ca354717dde9a9acfd7998c075487ba9500410", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditUserPermissions : Cella.Infrastructure.Framework.CellaRazorPage<Cella.Models.ViewModels.UserPermissionsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\GitMaster\Cella\Cella.Web\Views\Admin\EditUserPermissions.cshtml"
  
    ViewData["Title"] = "Users";
    Layout = "~/Views/Shared/_AdminLteLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""pull-right"" style=""float:right"">

         <a class=""btn bg-blue"" href=""/StockItems/Create"">
            <i class=""fa fa-plus-square""></i>
            Add new
        </a>
  
    
    <button type=""submit"" name=""download-catalog-pdf"" class=""btn bg-purple"" formaction=""/Admin/Product/DownloadCatalogPDF"">
        <i class=""fa fa-file-pdf-o""></i>
        Download catalog as PDF
    </button>
    <div class=""btn-group"">
        <button type=""button"" class=""btn btn-success"">
            <i class=""fa fa-download""></i>
            Export
        </button>
        <button type=""button"" class=""btn btn-success dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false"">
            <span class=""caret""></span>
            <span class=""sr-only"">&nbsp;</span>
        </button>
        <ul class=""dropdown-menu"" role=""menu"">
            <li>
                <button type=""submit"" name=""exportxml-all"" formaction=""/Admin/Product/ExportToXml"">
                    <i class=""fa fa-file-code-");
            WriteLiteral(@"o""></i>
                    Export to XML (all found)
                </button>
            </li>
            <li>
                <button type=""button"" id=""exportxml-selected"">
                    <i class=""fa fa-file-code-o""></i>
                    Export to XML (selected)
                </button>
            </li>
            <li class=""divider""></li>
            <li>
                <button type=""submit"" name=""exportexcel-all"" formaction=""/Admin/Product/ExportToExcel"">
                    <i class=""fa fa-file-excel-o""></i>
                    Export to Excel (all found)
                </button>
            </li>
            <li>
                <button type=""button"" id=""exportexcel-selected"">
                    <i class=""fa fa-file-excel-o""></i>
                    Export to Excel (selected)
                </button>
            </li>
        </ul>
    </div>
    <button type=""button"" name=""importexcel"" class=""btn bg-olive"" data-toggle=""modal"" data-target=""#importexcel-window""");
            WriteLiteral(@">
        <i class=""fa fa-upload""></i>
        Import
    </button>
  
        <button type=""button"" id=""delete-selected"" class=""btn bg-red"">
            <i class=""fa fa-trash-o""></i>
            Delete (selected)
        </button>
   

        <button type=""button"" id=""delete-selected"" disabled=""disabled"" title=""You do not have permissions contact manager!."" class=""btn bg-red"">
            <i class=""fa fa-trash-o""></i>
            Delete
        </button>
 

</div>
<table class=""table "">
    <tr>
        <th>Name</th>
        <th>Controller</th>
        <th>Area</th>
        <th>Status</th>

");
#nullable restore
#line 83 "D:\GitMaster\Cella\Cella.Web\Views\Admin\EditUserPermissions.cshtml"
         foreach (var item in Model.UserPermmissions)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 86 "D:\GitMaster\Cella\Cella.Web\Views\Admin\EditUserPermissions.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 87 "D:\GitMaster\Cella\Cella.Web\Views\Admin\EditUserPermissions.cshtml"
           Write(item.Controller);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n             \r\n                    <input type=\"checkbox\"/>\r\n                \r\n            \r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 95 "D:\GitMaster\Cella\Cella.Web\Views\Admin\EditUserPermissions.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ISharedResource SharedResource { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Cella.Models.ViewModels.UserPermissionsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
