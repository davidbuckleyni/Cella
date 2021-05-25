#pragma checksum "D:\GitMaster\Cella\Cella.Web\Views\Admin\Themes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcec8dd411b32da31f78252dc1e952719b786fec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Themes_Index), @"mvc.1.0.view", @"/Views/Admin/Themes/Index.cshtml")]
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
#line 1 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using Cella.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
using SharedResourceLib.Lng;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\GitMaster\Cella\Cella.Web\Views\_ViewImports.cshtml"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcec8dd411b32da31f78252dc1e952719b786fec", @"/Views/Admin/Themes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfaf1a045863d2adcb9f95773895f257c6a54026", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Themes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Cella.Models.ViewModels.ThemeListItemVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\GitMaster\Cella\Cella.Web\Views\Admin\Themes\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLteLayoutWithoutDashIcons.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h1>Theme Manager` </h1>
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
                    <button type=""submit"" name=""exportxml-all"" forma");
            WriteLiteral(@"ction=""/Admin/Product/ExportToXml"">
                        <i class=""fa fa-file-code-o""></i>
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
                    </but");
            WriteLiteral(@"ton>
                </li>
            </ul>
        </div>
        <button type=""button"" name=""importexcel"" class=""btn bg-olive"" data-toggle=""modal"" data-target=""#importexcel-window"">
            <i class=""fa fa-upload""></i>
            Import
        </button>
        <button type=""button"" id=""delete-selected"" class=""btn bg-red"">
            <i class=""fa fa-trash-o""></i>
            Delete (selected)
        </button>
    </div>

    <div class=""padding-top:10px;""></div>
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Image
                </th>

                <th>
                    ");
#nullable restore
#line 72 "D:\GitMaster\Cella\Cella.Web\Views\Admin\Themes\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ThemeListItem.First().Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 75 "D:\GitMaster\Cella\Cella.Web\Views\Admin\Themes\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ThemeListItem.First().DisplayName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 79 "D:\GitMaster\Cella\Cella.Web\Views\Admin\Themes\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ThemeListItem.First().ThumbnailUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 82 "D:\GitMaster\Cella\Cella.Web\Views\Admin\Themes\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ThemeListItem.First().IsCurrent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    Action\r\n                </th>\r\n\r\n            </tr>\r\n        </thead>\r\n    </table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Cella.Models.ViewModels.ThemeListItemVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
