#pragma checksum "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e70372a4d2d79bd9d31d892a1019bf5e4e10fa46"
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
#line 1 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\_ViewImports.cshtml"
using Bai_tap_bo_sung;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\_ViewImports.cshtml"
using Bai_tap_bo_sung.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e70372a4d2d79bd9d31d892a1019bf5e4e10fa46", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8b66bb6effeadf9c91aea4d3cda21fb94278b51", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
  
    var sv = ViewData["SV"] as List<SinhVien>;
    lstSv lst = new lstSv(sv);
    string a;
    string b;
    string c;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <h6>Sinh viên có điểm trung bình cao nhất là : ");
#nullable restore
#line 9 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
                                              Write(sv.Max(c => c.Diem));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n    <h6>Mã sinh viên của sinh viên là :</h6>\r\n");
#nullable restore
#line 11 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
      
        var lstSinhVienTemb = lst.LstSinhvien;


        for (int i = 0; i < lst.LstSinhvien.Count; i++)
        {
            int lenghtFullName = lst.LstSinhvien[i].Name.Split(" ").Length;

            for (int j = 0; j < lenghtFullName - 1; j++)
            {
                var charText = lst.LstSinhvien[i].Name.Split(" ")[j];
                var charIndex1 = charText.Substring(0, 1);
                lstSinhVienTemb[i].Name = lstSinhVienTemb[i].Name + charIndex1;

            }
            lstSinhVienTemb[i].Name = lst.LstSinhvien[i].Name.Split(" ")[lenghtFullName - 1];
        }
        int index1 = 1;
        var lsttemb = lstSinhVienTemb.OrderBy(c => c.Name).ToList();
        for (int i = 0; i < lsttemb.Count; i++)
        {
            if (i + 1 == lsttemb.Count)
            {
                break;

            }
            if (lsttemb[i].Name == lsttemb[i + 1].Name)
            {
                lsttemb[i + 1].Name = lsttemb[i + 1].Name + index1;
                ++index1;
                ++i;
            }
            else
            {
                index1 = 1;
            }
            if (i == lsttemb.Count)
            {
                break;
            }
        }
        foreach (var x in lsttemb)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p> ");
#nullable restore
#line 54 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
           Write(x.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(", Ten ");
#nullable restore
#line 54 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
                      Write(x.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(", Diem ");
#nullable restore
#line 54 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
                                    Write(x.Diem);

#line default
#line hidden
#nullable disable
            WriteLiteral(", Tuoi ");
#nullable restore
#line 54 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
                                                  Write(x.Tuoi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 55 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
            }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h6>Người có tuổi lớn thứ 2 là : </h6>\r\n");
#nullable restore
#line 59 "C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\Views\Home\Index.cshtml"
      

       Random random = new Random();
       int length = lst.LstSinhvien.Count;

       for (var i = 0; i < length; i++)
       {
           lst.LstSinhvien[i].Name += ((int)(random.Next(1, 26) + 64)).ToString().ToLower();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
