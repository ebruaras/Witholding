#pragma checksum "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\CallCenter\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b67467522daaf5381e4e101d058502e6c8b2bb5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CallCenter_Login), @"mvc.1.0.view", @"/Views/CallCenter/Login.cshtml")]
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
#line 1 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\_ViewImports.cshtml"
using Stopaj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\_ViewImports.cshtml"
using Stopaj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b67467522daaf5381e4e101d058502e6c8b2bb5d", @"/Views/CallCenter/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4447e7c28f861890242fffde902681c395d6e6f9", @"/Views/_ViewImports.cshtml")]
    public class Views_CallCenter_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\CallCenter\Login.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row justify-content-md-center align-items-center\">\r\n    <div class=\"col col-lg-2\">\r\n\r\n    </div>\r\n    <div class=\"col-md-6 align-self-center\" style=\"top:200px\">\r\n        <h3>CallCenter Login</h3>\r\n");
#nullable restore
#line 12 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\CallCenter\Login.cshtml"
         if (ViewBag.LoginResult != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"p-3 mb-2 bg-danger text-white\">");
#nullable restore
#line 14 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\CallCenter\Login.cshtml"
                                      Write(ViewBag.LoginResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
#nullable restore
#line 14 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\CallCenter\Login.cshtml"
                                                                     }

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\CallCenter\Login.cshtml"
         using (Html.BeginForm("Login", "CallCenter", FormMethod.Post, new { name = "callcenterloginform" }))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-group\">\r\n    <input type=\"text\" class=\"form-control\" placeholder=\"Kullanıcı ID\"");
            BeginWriteAttribute("value", " value=\"", 598, "\"", 606, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"DealerId\" required>\r\n</div>\r\n                <div class=\"form-group\">\r\n                    <input type=\"password\" class=\"form-control\" placeholder=\"Şifre\"");
            BeginWriteAttribute("value", " value=\"", 768, "\"", 776, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""Password"" required>
                </div>
                                <div class=""form-group"">
                                    <input type=""submit"" class=""btn btn-primary"" style=""width:50%; float:right"" value=""Giriş"">
                                </div>");
#nullable restore
#line 25 "C:\Users\EBRU\source\repos\Stopaj\Stopaj\Views\CallCenter\Login.cshtml"
                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"col col-lg-2\">\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
