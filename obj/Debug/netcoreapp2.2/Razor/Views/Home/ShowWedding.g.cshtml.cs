#pragma checksum "/Users/rtongson/Documents/csharp/entity/WeddingPlanner/Views/Home/ShowWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d17ecd8502ffdd791efead5307f0a206b678700"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowWedding), @"mvc.1.0.view", @"/Views/Home/ShowWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ShowWedding.cshtml", typeof(AspNetCore.Views_Home_ShowWedding))]
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
#line 1 "/Users/rtongson/Documents/csharp/entity/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "/Users/rtongson/Documents/csharp/entity/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d17ecd8502ffdd791efead5307f0a206b678700", @"/Views/Home/ShowWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/rtongson/Documents/csharp/entity/WeddingPlanner/Views/Home/ShowWedding.cshtml"
  
  ViewData["Title"] = "Wedding Planner";

#line default
#line hidden
            BeginContext(61, 12, true);
            WriteLiteral("<div>\n  <h1>");
            EndContext();
            BeginContext(74, 15, false);
#line 6 "/Users/rtongson/Documents/csharp/entity/WeddingPlanner/Views/Home/ShowWedding.cshtml"
 Write(Model.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(89, 5, true);
            WriteLiteral(" and ");
            EndContext();
            BeginContext(95, 15, false);
#line 6 "/Users/rtongson/Documents/csharp/entity/WeddingPlanner/Views/Home/ShowWedding.cshtml"
                      Write(Model.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(110, 69, true);
            WriteLiteral("\'s Wedding </h1>\n  <br>\n  <h2>Guests:</h2>\n  <ul>\n    \n  </ul>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
