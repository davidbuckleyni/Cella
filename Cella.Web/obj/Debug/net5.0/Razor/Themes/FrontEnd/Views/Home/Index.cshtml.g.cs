#pragma checksum "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2094dc00a461c1160320a089439239c38368e64f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Themes_FrontEnd_Views_Home_Index), @"mvc.1.0.view", @"/Themes/FrontEnd/Views/Home/Index.cshtml")]
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
#line 2 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\_ViewImports.cshtml"
using Cella.BL.TagHelpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\_ViewImports.cshtml"
using Cella.BL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2094dc00a461c1160320a089439239c38368e64f", @"/Themes/FrontEnd/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98c1374fad4e74238c7e4a2cbc4154e90dfde85c", @"/Themes/FrontEnd/_ViewImports.cshtml")]
    public class Themes_FrontEnd_Views_Home_Index : Cella.Infrastructure.Framework.CellaRazorPage<Cella.Models.ViewModels.ProductListingsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Prop";
    Layout = "~/Themes/FrontEnd/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 8 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\Views\Home\Index.cshtml"
Write(T("Search"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\nLets show a price  \r\n");
#nullable restore
#line 11 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\Views\Home\Index.cshtml"
 foreach (var item in Model.Products)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>\r\n    Price:    \r\n    ");
#nullable restore
#line 15 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\Views\Home\Index.cshtml"
Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</li>\r\n");
#nullable restore
#line 17 "D:\GitMaster\Cella\Cella.Web\Themes\FrontEnd\Views\Home\Index.cshtml"
 
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Cella.Models.ViewModels.ProductListingsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
