#pragma checksum "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63e12499531765c9e45fc339fc586677c4cc5023"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Navbar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Navbar/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63e12499531765c9e45fc339fc586677c4cc5023", @"/Views/Shared/Components/Navbar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a533d865d4066f0c8d755d0609836d3cc8b23394", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Navbar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PresenileNotes.Web.Models.HomeModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"page-header navbar navbar-fixed-top\">\r\n    <div class=\"page-header-inner\">\r\n        <div class=\"page-logo workspace\">\r\n");
#nullable restore
#line 5 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
             if (Model.Workspace != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 251, "\"", 314, 1);
#nullable restore
#line 7 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
WriteAttributeValue("", 258, Url.Action("Home","Index",new { id=Model.Workspace.Id}), 258, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"logo-default\">\r\n                    <span>");
#nullable restore
#line 8 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
                     Write(Model.Workspace.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </a>\r\n");
#nullable restore
#line 10 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"menu-toggler sidebar-toggler\"> </div>\r\n        </div>\r\n        <a href=\"javascript:;\" class=\"menu-toggler responsive-toggler\" data-toggle=\"collapse\" data-target=\".navbar-collapse\"> </a>\r\n");
#nullable restore
#line 14 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
         if (Model.Workspaces != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"top-menu\" style=\"float:left;\">\r\n                <ul class=\"nav navbar-nav navbar-left\">\r\n\r\n");
#nullable restore
#line 19 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
                     foreach (var item in Model.Workspaces)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 953, "\"", 961, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"float:left;\"");
            BeginWriteAttribute("href", " href=\"", 982, "\"", 1033, 1);
#nullable restore
#line 22 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
WriteAttributeValue("", 989, Url.Action("Index","Home",new {id=item.Id}), 989, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
                                                                                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </li>\r\n");
#nullable restore
#line 24 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n                <ul class=\"nav navbar-nav\" style=\"float:right;\">\r\n                </ul>\r\n            </div>\r\n            <div class=\"top-menu-right\">\r\n                <a class=\"navbar-brand\" style=\"float:right;  \"");
            BeginWriteAttribute("href", " href=\"", 1341, "\"", 1378, 1);
#nullable restore
#line 30 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
WriteAttributeValue("", 1348, Url.Action("Settings","Home"), 1348, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                    <i class=""icon-settings""></i>
                </a>
                <a class=""navbar-brand"" style=""float:right;"" href=""javascript:;"" id=""addWorkspace"">
                    <i class=""icon-plus""></i>
                </a>
            </div>
");
#nullable restore
#line 37 "C:\Users\gorkem\source\repos\PresenileNotes\PresenileNotes.Web\Views\Shared\Components\Navbar\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
