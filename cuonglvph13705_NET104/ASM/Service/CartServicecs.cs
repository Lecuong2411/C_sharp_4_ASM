using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using ASM.Models;
using Newtonsoft.Json;

namespace ASM.Service
{
    public class CartServicecs
    {
        //// Key lưu chuỗi json của Cart
        //public const string CARTKEY = "cart";

        //private readonly IHttpContextAccessor _context;
        //private readonly HttpContext httpContext;
        //public CartServicecs(HttpContextAccessor context)
        //{
        //    _context = context;
        //}
        //// Lấy cart từ Session (danh sách CartItem)
        //public List<GioHang_ChiTiet> GetCart()
        //{

        //    var session = httpContext.Session;
        //    string jsoncart = session.GetString(CARTKEY);
        //    if (jsoncart != null)
        //    {
        //        return JsonConvert.DeserializeObject<List<GioHang_ChiTiet>>(jsoncart);
        //    }
        //    return new List<GioHang_ChiTiet>();
        //}

        //// Xóa cart khỏi session
        //public void ClearCart()
        //{
        //    var session = httpContext.Session;
        //    session.Remove(CARTKEY);
        //}

        //// Lưu Cart (Danh sách CartItem) vào session
        //public void SaveCartSession(List<GioHang_ChiTiet> ls)
        //{
        //    var session = httpContext.Session;
        //    string jsoncart = JsonConvert.SerializeObject(ls);
        //    session.SetString(CARTKEY, jsoncart);
        //}
    }
}
