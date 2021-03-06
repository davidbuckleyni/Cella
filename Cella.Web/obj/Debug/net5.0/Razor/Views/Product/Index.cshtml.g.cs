#pragma checksum "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17b4bb1007acfb65ff32c291f40b77e1aa85f50c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17b4bb1007acfb65ff32c291f40b77e1aa85f50c", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04ca354717dde9a9acfd7998c075487ba9500410", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : Cella.Infrastructure.Framework.CellaRazorPage<Cella.Models.StockItemVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLteLayoutWithoutDashIcons.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>Products </h1>\r\n<div class=\"pull-right\" style=\"float:right\">\r\n\r\n");
#nullable restore
#line 12 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
     if (Model.UserPermissions.Any(w => w.Action == "Create" && w.Authorized == true))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a class=\"btn bg-blue\" href=\"/StockItems/Create\">\r\n            <i class=\"fa fa-plus-square\"></i>\r\n            Add new\r\n        </a>\r\n");
#nullable restore
#line 18 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
    }
    else
    { 


#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"button\" id=\"delete-selected\" disabled=\"disabled\" title=\"You do not have permissions contact manager!.\" class=\"btn bg-red\">\r\n\r\n\r\n        <i class=\"fa fa-plus-square\"></i>\r\n        Add\r\n       </button>\r\n");
#nullable restore
#line 28 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <button type=""submit"" name=""download-catalog-pdf"" class=""btn bg-purple"" formaction=""/Admin/Product/DownloadCatalogPDF"">
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
                    <i class=""fa fa-file-code-o""></i>
                    Export to XML (all found)
                </button>
            </li>
            <li>
                <button type=""button"" id=""exportxml-selected"">
                  ");
            WriteLiteral(@"  <i class=""fa fa-file-code-o""></i>
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
    <button type=""button"" name=""importexcel"" class=""btn bg-olive"" data-toggle=""modal"" data-target=""#importexcel-window"">
        <i class=""fa fa-upload""></i>
        Import
    </button>
");
#nullable restore
#line 75 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
     if (Model.UserPermissions.Any(w => w.Action == "Delete" && w.Authorized == true))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button type=\"button\" id=\"delete-selected\" class=\"btn bg-red\">\r\n            <i class=\"fa fa-trash-o\"></i>\r\n            Delete (selected)\r\n        </button>\r\n");
#nullable restore
#line 81 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
    }
    else
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <button type=\"button\" id=\"delete-selected\" disabled=\"disabled\" title=\"You do not have permissions contact manager!.\" class=\"btn bg-red\">\r\n            <i class=\"fa fa-trash-o\"></i>\r\n            Delete\r\n        </button>\r\n");
#nullable restore
#line 89 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"padding-top:10px;\"></div>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    Image\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 102 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.StockItems.First().Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 105 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.StockItems.First().StockCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 108 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.StockItems.First().BarCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 111 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.StockItems.First().SKU));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n              \r\n                <th>\r\n                    ");
#nullable restore
#line 115 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.StockItems.First().ShortDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Action\r\n                </th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 124 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
             foreach (var item in Model.StockItems)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                   <img src=\"https://via.placeholder.com/100\" />\r\n\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 132 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 135 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.StockCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 138 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.BarCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 141 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SKU));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n               \r\n             \r\n\r\n                <td>\r\n                    \r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17b4bb1007acfb65ff32c291f40b77e1aa85f50c12772", async() => {
                WriteLiteral("<i class=\"fa fa-pencil\"></i>Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 149 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("                    \r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 152 "D:\GitMaster\Cella\Cella.Web\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Cella.Models.StockItemVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
