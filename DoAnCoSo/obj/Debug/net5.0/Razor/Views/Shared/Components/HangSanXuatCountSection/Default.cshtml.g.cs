#pragma checksum "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "402c3943eab523902fd39537573e6220bf051d76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HangSanXuatCountSection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HangSanXuatCountSection/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"402c3943eab523902fd39537573e6220bf051d76", @"/Views/Shared/Components/HangSanXuatCountSection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ecaa3d83ad4b046df131383aab6b5faef7275d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_HangSanXuatCountSection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<DoAnCoSo.Data.ModelHelper.DanhMucCountClientModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
  
	var first = Model.First();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"awe-section-3\">\r\n\t<div class=\"container evo_block-product\">\r\n\t\t<div class=\"evo-block-product-big evo-block-cate-new\">\r\n\t\t\t<div class=\"featured--content\">\r\n\t\t\t\t<div class=\"featured__first\">\r\n\t\t\t\t\t<a href=\"/dien-thoai\"");
            BeginWriteAttribute("title", " title=\"", 341, "\"", 363, 1);
#nullable restore
#line 11 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
WriteAttributeValue("", 349, first.TenHang, 349, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"ps-product--vertical\">\r\n\t\t\t\t\t\t<div class=\"evo-new-has-img\">\r\n\t\t\t\t\t\t\t<img style=\"opacity: 1; background: none;\"");
            BeginWriteAttribute("src", " src=\"", 482, "\"", 525, 2);
            WriteAttributeValue("", 488, "/Images/HangSanXuat/", 488, 20, true);
#nullable restore
#line 13 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
WriteAttributeValue("", 508, first.AnhDaiDien, 508, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n\t\t\t\t\t\t\t\t alt=\"", 526, "\"", 556, 1);
#nullable restore
#line 14 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
WriteAttributeValue("", 542, first.TenHang, 542, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"lazy img-responsive mx-auto d-block\" />\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<div class=\"ps-product__content\">\r\n\t\t\t\t\t\t\t<div class=\"ps-product__name\">");
#nullable restore
#line 17 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
                                                     Write(first.TenHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\t\t\t\t\t\t\t<p class=\"ps-product__quantity\">");
#nullable restore
#line 18 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
                                                       Write(first.SanPhamCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" sản phẩm</p>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</a>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div class=\"featured__group\">\r\n\t\t\t\t\t<div class=\"row m-0\">\r\n");
#nullable restore
#line 24 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
                         for (int i = 1; i < Model.Count - 1; i++)
						{
							var item = Model.ElementAt(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<div class=\"col-3 p-0\">\r\n\t\t\t\t\t\t\t\t<a href=\"#\"");
            BeginWriteAttribute("title", " title=\"", 1042, "\"", 1063, 1);
#nullable restore
#line 28 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
WriteAttributeValue("", 1050, item.TenHang, 1050, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"ps-product--vertical\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"evo-new-has-img\">\r\n\t\t\t\t\t\t\t\t\t\t<img style=\"opacity: 1; background: none;\"");
            BeginWriteAttribute("src", " src=\"", 1188, "\"", 1230, 2);
            WriteAttributeValue("", 1194, "/Images/HangSanXuat/", 1194, 20, true);
#nullable restore
#line 30 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
WriteAttributeValue("", 1214, item.AnhDaiDien, 1214, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n\t\t\t\t\t\t\t\t\t\t\t alt=\"", 1231, "\"", 1263, 1);
#nullable restore
#line 31 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
WriteAttributeValue("", 1250, item.TenHang, 1250, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"lazy img-responsive mx-auto d-block\" />\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"ps-product__content\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"ps-product__name\">");
#nullable restore
#line 34 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
                                                                 Write(item.TenHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\t\t\t\t\t\t\t\t\t\t<p class=\"ps-product__quantity\">");
#nullable restore
#line 35 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
                                                                   Write(item.SanPhamCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" sản phẩm</p>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 39 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\HangSanXuatCountSection\Default.cshtml"
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<DoAnCoSo.Data.ModelHelper.DanhMucCountClientModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591