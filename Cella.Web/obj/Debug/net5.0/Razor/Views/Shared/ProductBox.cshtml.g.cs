#pragma checksum "D:\GitMaster\Cella\Cella.Web\Views\Shared\ProductBox.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bef1073a3ef8b247dca8d4542a351a0dd170621"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ProductBox), @"mvc.1.0.view", @"/Views/Shared/ProductBox.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bef1073a3ef8b247dca8d4542a351a0dd170621", @"/Views/Shared/ProductBox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04ca354717dde9a9acfd7998c075487ba9500410", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ProductBox : Cella.Infrastructure.Framework.CellaRazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"product-item\" data-productid=\"");
#nullable restore
#line 1 "D:\GitMaster\Cella\Cella.Web\Views\Shared\ProductBox.cshtml"
                                     Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n    <div class=\"picture\">\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
