#pragma checksum "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6879272586db36897f5ca1f7800dc63bd4fe01f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\_ViewImports.cshtml"
using AspNetCoreMVCApp;

#line default
#line hidden
#line 2 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\_ViewImports.cshtml"
using AspNetCoreMVCApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6879272586db36897f5ca1f7800dc63bd4fe01f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"350dc4dc512a9278fc2de1723ed1e1c0787787e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("address", "kedarvaidya22@gmail.com", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/download.jpeg", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("fallback-url", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::AspNetCoreMVCApp.TagHelpers.EmailTagHelper __AspNetCoreMVCApp_TagHelpers_EmailTagHelper;
        private global::AspNetCoreMVCApp.TagHelpers.ImageTagHelper __AspNetCoreMVCApp_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 187, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n    ");
            EndContext();
            BeginContext(232, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("email", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6879272586db36897f5ca1f7800dc63bd4fe01f4527", async() => {
            }
            );
            __AspNetCoreMVCApp_TagHelpers_EmailTagHelper = CreateTagHelper<global::AspNetCoreMVCApp.TagHelpers.EmailTagHelper>();
            __tagHelperExecutionContext.Add(__AspNetCoreMVCApp_TagHelpers_EmailTagHelper);
            __AspNetCoreMVCApp_TagHelpers_EmailTagHelper.Address = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(275, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(281, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("image", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6879272586db36897f5ca1f7800dc63bd4fe01f5746", async() => {
            }
            );
            __AspNetCoreMVCApp_TagHelpers_ImageTagHelper = CreateTagHelper<global::AspNetCoreMVCApp.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__AspNetCoreMVCApp_TagHelpers_ImageTagHelper);
            __AspNetCoreMVCApp_TagHelpers_ImageTagHelper.Src = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __AspNetCoreMVCApp_TagHelpers_ImageTagHelper.FallbackUrl = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(327, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(334, 19, false);
#line 10 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml"
Write(ViewBag.LoadingTime);

#line default
#line hidden
            EndContext();
            BeginContext(353, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml"
     foreach(var item in ViewBag.Users)
    {

#line default
#line hidden
            BeginContext(403, 11, true);
            WriteLiteral("        <p>");
            EndContext();
            BeginContext(415, 8, false);
#line 13 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml"
      Write(item.Key);

#line default
#line hidden
            EndContext();
            BeginContext(423, 4, true);
            WriteLiteral(" -- ");
            EndContext();
            BeginContext(428, 10, false);
#line 13 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml"
                   Write(item.Value);

#line default
#line hidden
            EndContext();
            BeginContext(438, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 14 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(451, 19, true);
            WriteLiteral("        <p>Source: ");
            EndContext();
            BeginContext(471, 14, false);
#line 15 "D:\dotnetcore\AspNetCoreMVCApp\AspNetCoreMVCApp\Views\Home\Index.cshtml"
              Write(ViewBag.Source);

#line default
#line hidden
            EndContext();
            BeginContext(485, 15, true);
            WriteLiteral("</p> \r\n</div>\r\n");
            EndContext();
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
