#pragma checksum "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52d6890f9da52098b0e2a55b89a1b880f5641c84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Sidebar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Sidebar/Default.cshtml")]
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
#line 1 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\_ViewImports.cshtml"
using PresenileNotes.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\_ViewImports.cshtml"
using PresenileNotes.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52d6890f9da52098b0e2a55b89a1b880f5641c84", @"/Views/Shared/Components/Sidebar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a533d865d4066f0c8d755d0609836d3cc8b23394", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Sidebar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PresenileNotes.Web.Models.HomeModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Auth/LogOut"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link nav-toggle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""page-sidebar-wrapper"">
    <div class=""page-sidebar navbar-collapse collapse"">
        <ul class=""page-sidebar-menu  page-header-fixed "" data-keep-expanded=""false"" data-auto-scroll=""true"" data-slide-speed=""200"" style=""padding-top: 20px"">
            <li id=""dashbord"" class=""nav-item"">
                <a");
            BeginWriteAttribute("href", " href=\"", 364, "\"", 398, 1);
#nullable restore
#line 6 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 371, Url.Action("Index","Home"), 371, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link nav-toggle\">\r\n                    <i class=\"icon-home\"></i>\r\n                    <span class=\"title\">Home</span>\r\n\r\n                </a>\r\n            </li>\r\n");
#nullable restore
#line 12 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
             if (Model.Workspace != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <li id=""dashbord"" class=""nav-item"">
                    <a href=""javascript:;"" class=""nav-link nav-toggle"" id=""addCategory"">
                        <i class=""icon-plus""></i>
                        <span class=""title"">Create Category</span>

                    </a>
                </li>
");
#nullable restore
#line 21 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
             if (Model.Categories != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                 foreach (var item in Model.Categories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li");
            BeginWriteAttribute("id", " id=\"", 1117, "\"", 1133, 1);
#nullable restore
#line 26 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 1122, item.Class, 1122, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-item \">\r\n\r\n                        <a href=\"javascript:;\" class=\"nav-link nav-toggle\">\r\n                            <i class=\"fa fa-sticky-note-o\" aria-hidden=\"true\"></i>\r\n                            <span class=\"title\">");
#nullable restore
#line 30 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <span");
            BeginWriteAttribute("id", " id=\"", 1418, "\"", 1441, 2);
            WriteAttributeValue("", 1423, "select-", 1423, 7, true);
#nullable restore
#line 31 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 1430, item.Class, 1430, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1442, "\"", 1450, 0);
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                            <span id=\"Menuarrow\" class=\"arrow \"></span>\r\n                        </a>\r\n");
#nullable restore
#line 34 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                         if (Model.Notes != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <ul class=""sub-menu"">

                                <li id=""sub-blog"" class=""nav-item  "">

                                    <a href=""javascript:;"" class=""btn btn-outline btn-circle green btn-sm green-dark"" style=""text-align:center;"" id=""addNote""");
            BeginWriteAttribute("name", " name=\"", 1925, "\"", 1940, 1);
#nullable restore
#line 40 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 1932, item.Id, 1932, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        Create New Note <i class=\"fa fa-plus\"></i>\r\n\r\n                                        <span id=\"sub-blogselect\"");
            BeginWriteAttribute("class", " class=\"", 2095, "\"", 2103, 0);
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                                    </a>\r\n                                </li>\r\n");
#nullable restore
#line 46 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                                 foreach (var note in Model.Notes)
                                {
                                    if (note != null)
                                    {
                                        if (note.CategoryId == item.Id)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li");
            BeginWriteAttribute("id", " id=\"", 2555, "\"", 2580, 3);
#nullable restore
#line 52 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 2560, note.Class, 2560, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2571, "-", 2571, 1, true);
#nullable restore
#line 52 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 2572, note.Id, 2572, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-item  \">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 2653, "\"", 2706, 1);
#nullable restore
#line 53 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 2660, Url.Action("Note", "Home", new { id=note.Id}), 2660, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link \">\r\n                                                    <i class=\"fa fa-edit\"></i>\r\n                                                    <span class=\"title\">\r\n                                                        ");
#nullable restore
#line 56 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                                                   Write(note.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </span>\r\n                                                    <span");
            BeginWriteAttribute("id", " id=\"", 3069, "\"", 3098, 4);
            WriteAttributeValue("", 3074, "sub-", 3074, 4, true);
#nullable restore
#line 58 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 3078, note.Class, 3078, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3089, "-", 3089, 1, true);
#nullable restore
#line 58 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
WriteAttributeValue("", 3090, note.Id, 3090, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 3099, "\"", 3107, 0);
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                                                </a>\r\n                                            </li>\r\n");
#nullable restore
#line 61 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                                        }
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </ul>\r\n");
#nullable restore
#line 66 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 68 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Sidebar\Default.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li id=\"Logout\" class=\"nav-item\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52d6890f9da52098b0e2a55b89a1b880f5641c8414003", async() => {
                WriteLiteral("\r\n                    <i class=\"icon-logout\"></i>\r\n                    <span class=\"title\">Sign out</span>\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n        </ul>\r\n\r\n        <!-- END SIDEBAR MENU -->\r\n        <!-- END SIDEBAR MENU -->\r\n    </div>\r\n    <!-- END SIDEBAR -->\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PresenileNotes.Web.Models.HomeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
