#pragma checksum "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b55b8354da4f5dc55dcdb4a10bb9dc701c0e55d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
#line 1 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\_ViewImports.cshtml"
using SimpleWebAppMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\_ViewImports.cshtml"
using SimpleWebAppMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b55b8354da4f5dc55dcdb4a10bb9dc701c0e55d", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04384388758ad716506c8ed2f477768c98da3d8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml"
  
    ViewData["title"] = "About";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>");
#nullable restore
#line 5 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml"
Write(ViewData["title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n\n<div class=\"jumbotron\">\n    <h3>");
#nullable restore
#line 8 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml"
   Write(Model.AppName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n\n    <p>\n        ");
#nullable restore
#line 11 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml"
   Write(Model.Version);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n        &copy; ");
#nullable restore
#line 12 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml"
          Write(Model.Copyright);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n        <a");
            BeginWriteAttribute("href", " href=\"", 206, "\"", 223, 1);
#nullable restore
#line 13 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml"
WriteAttributeValue("", 213, Model.Url, 213, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 13 "C:\Users\David Faynzilberg\source\repos\BRMSTools.Web\Views\Home\About.cshtml"
                        Write(Model.Url);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n    </p>\n</div>");
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
