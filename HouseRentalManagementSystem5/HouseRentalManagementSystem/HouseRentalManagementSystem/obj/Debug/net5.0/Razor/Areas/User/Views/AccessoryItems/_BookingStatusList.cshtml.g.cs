#pragma checksum "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\Views\AccessoryItems\_BookingStatusList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85ef528b9ce264f9535a485f1cdb49037c4e6b7d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_AccessoryItems__BookingStatusList), @"mvc.1.0.view", @"/Areas/User/Views/AccessoryItems/_BookingStatusList.cshtml")]
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
#line 1 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\_ViewImports.cshtml"
using HouseRentalManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\_ViewImports.cshtml"
using HouseRentalManagementSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\_ViewImports.cshtml"
using HouseRentalManagementSystem.UserViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85ef528b9ce264f9535a485f1cdb49037c4e6b7d", @"/Areas/User/Views/AccessoryItems/_BookingStatusList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42bb347e0d9e320667f64af44f4ad16dc9108501", @"/Areas/User/_ViewImports.cshtml")]
    public class Areas_User_Views_AccessoryItems__BookingStatusList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <table class=""table table-bordered table-striped list_table"">
        <thead>
            <tr>
                <th class=""text-center"">
                    ###
                </th>
                <th>
                    Booking Status
                </th>
                <th class=""text-center tbl_action"">Actions</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 16 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\Views\AccessoryItems\_BookingStatusList.cshtml"
             foreach (var item in Model.BookingStatusViewModel)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"text-center\">\r\n                        ");
#nullable restore
#line 20 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\Views\AccessoryItems\_BookingStatusList.cshtml"
                   Write(item.SirialNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 23 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\Views\AccessoryItems\_BookingStatusList.cshtml"
                   Write(item.BookingStatusDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n");
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 39 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\Views\AccessoryItems\_BookingStatusList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div>\r\n    <div class=\"page_section\">\r\n        ");
#nullable restore
#line 45 "F:\SOHAN\EidUlAzaha\Final-Project\AspDotNetCore\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\Areas\User\Views\AccessoryItems\_BookingStatusList.cshtml"
   Write(Html.PagedListPager((IPagedList)Model.BookingStatusViewModel, bookingStatusPage => Url.Action("Index", new { bookingStatusPage = bookingStatusPage }),
    new X.PagedList.Web.Common.PagedListRenderOptions
    {
        ContainerDivClasses = new[] { "navication" },
        LiElementClasses = new[] { "page-item" },
        PageClasses = new[] { "page-link" },
    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
