#pragma checksum "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee5203a9f280925538901e708b51f4b528ba6b55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_PhuKien_Default), @"mvc.1.0.view", @"/Views/Shared/Components/PhuKien/Default.cshtml")]
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
#line 1 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\_ViewImports.cshtml"
using DoAnCoSo.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee5203a9f280925538901e708b51f4b528ba6b55", @"/Views/Shared/Components/PhuKien/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2917e02d85e2505fd7dedf242dac747a42c0cd11", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_PhuKien_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<DoAnCoSo.Data.ModelHelper.SanPhamReviewClientModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"evo_section_product evo-block-product row evo-wrap-mb phu-kien-area\">\r\n");
#nullable restore
#line 4 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
     foreach (var item in Model)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<div class=\"col-lg-4 col-md-6 col-sm-12 col-12 item\">\r\n\t\t\t<div class=\"evo-product-block-item evo-product-block-item-small\">\r\n\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 325, "\"", 359, 2);
            WriteAttributeValue("", 332, "/chitietsanpham?id=", 332, 19, true);
#nullable restore
#line 8 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
WriteAttributeValue("", 351, item.Id, 351, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 360, "\"", 384, 1);
#nullable restore
#line 8 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
WriteAttributeValue("", 368, item.TenSanPham, 368, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product__box-image\">\r\n\t\t\t\t\t<img class=\"lazy\"");
            BeginWriteAttribute("src", " src=\"", 437, "\"", 475, 2);
            WriteAttributeValue("", 443, "/Images/SanPham/", 443, 16, true);
#nullable restore
#line 9 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
WriteAttributeValue("", 459, item.AnhDaiDien, 459, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n\t\t\t\t\t\t alt=\"", 476, "\"", 506, 1);
#nullable restore
#line 10 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
WriteAttributeValue("", 490, item.TenSanPham, 490, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t\t<span class=\"sales\">\r\n\t\t\t\t\t\t<i class=\"icon-flash2\"></i> Giảm\r\n\t\t\t\t\t\t");
#nullable restore
#line 13 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
                   Write(item.GiaKhuyenMai?.ToString("#,###đ"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</span>\r\n\t\t\t\t</a>\r\n\t\t\t\t<div class=\"evo-product-right\">\r\n\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 693, "\"", 727, 2);
            WriteAttributeValue("", 700, "/chitietsanpham?id=", 700, 19, true);
#nullable restore
#line 17 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
WriteAttributeValue("", 719, item.Id, 719, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 728, "\"", 752, 1);
#nullable restore
#line 17 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
WriteAttributeValue("", 736, item.TenSanPham, 736, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product__box-name\">");
#nullable restore
#line 17 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
                                                                                                        Write(item.TenSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t<div class=\"product__box-price\">\r\n\t\t\t\t\t\t<span class=\"price\">");
#nullable restore
#line 19 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
                                       Write(item.GiaHienTai?.ToString("#,###đ"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t<span class=\"old-price\">");
#nullable restore
#line 20 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
                                           Write(item.GiaGoc.ToString("#,###đ"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div class=\"evo-tag\">\r\n\t\t\t\t\t\t<span>Trả góp 0% lãi suất</span>\r\n\t\t\t\t\t\t<span>Bảo hành trong 1 tháng</span>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div class=\"product__box-btn\">\r\n\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 1174, "\"", 1208, 2);
            WriteAttributeValue("", 1181, "/chitietsanpham?id=", 1181, 19, true);
#nullable restore
#line 28 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
WriteAttributeValue("", 1200, item.Id, 1200, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-buy\" title=\"Chi tiết\">Chi tiết</a>\r\n\t\t\t\t\t<a href=\"#\" title=\"Yêu thích\" data-id=\"");
#nullable restore
#line 29 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
                                                      Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn-compare like-button\">Yêu thích</a>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n");
#nullable restore
#line 33 "D:\C#\DoAnCoSo\DoAnCoSo\DoAnCoSo\Views\Shared\Components\PhuKien\Default.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<DoAnCoSo.Data.ModelHelper.SanPhamReviewClientModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591