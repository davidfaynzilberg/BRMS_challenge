#pragma checksum "E:\Source Code\GitHub\BRMS_challenge\BRMSTools.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1391bed398e51c4227db049bf8d18a417890db64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "E:\Source Code\GitHub\BRMS_challenge\BRMSTools.Web\Views\_ViewImports.cshtml"
using SimpleWebAppMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Source Code\GitHub\BRMS_challenge\BRMSTools.Web\Views\_ViewImports.cshtml"
using SimpleWebAppMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1391bed398e51c4227db049bf8d18a417890db64", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04384388758ad716506c8ed2f477768c98da3d8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Source Code\GitHub\BRMS_challenge\BRMSTools.Web\Views\Home\Index.cshtml"
  
    ViewData["title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Borrower Risk Management System</h2>\n\n<div class=\"jumbotron\">\n    <h3>");
#nullable restore
#line 8 "E:\Source Code\GitHub\BRMS_challenge\BRMSTools.Web\Views\Home\Index.cshtml"
   Write(ViewData["message_short"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n    <p>");
#nullable restore
#line 9 "E:\Source Code\GitHub\BRMS_challenge\BRMSTools.Web\Views\Home\Index.cshtml"
  Write(ViewData["message_long"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n</div>\n");
        }
        #pragma warning restore 1998
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
