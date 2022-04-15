using ASM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Service;

namespace ASM.Controllers
{
    public class CartController : Controller
    {
        private readonly QLBHContext _context;
        private readonly CartServicecs _cartServicecs;
        List<SanPham> _lstSanPhams;
        List<GioHang> _lstGioHangs;
        List<GioHang_ChiTiet> _lstGioHangchitiet;
        List<DanhMuc> _lstdoanhmuc;
        List<KhachHang> _lstKhachHang;
       
        GioHang _giohang;
        GioHang_ChiTiet _gioHang_ChiTiet;
        List<AddGioHang> _lstaddGioHangs;
      
        public CartController(QLBHContext context, CartServicecs cartServicecs)
        {
            this._context = context;


            _giohang = new GioHang();
            _gioHang_ChiTiet = new GioHang_ChiTiet();
            _lstaddGioHangs = new List<AddGioHang>();
            _lstSanPhams = _context.sanPhams.ToList();
            _lstGioHangs = _context.gioHangs.ToList();
            _lstGioHangchitiet = _context.gioHang_ChiTiets.ToList();
            _cartServicecs = cartServicecs;
        }
        
        public IActionResult Index()
        {
           ViewBag.cart= _context.gioHang_ChiTiets.ToList();
          ViewBag.total= viewGioHangs().Where(c => c.gioHang.MaGioHang == _giohang.MaGioHang).Sum(c => c.gioHang_ChiTiet.Thanhtien);
            return View();
        }

        public List<AddGioHang> viewGioHangs()
        {

            _lstaddGioHangs = new List<AddGioHang>();
            _lstSanPhams = _context.sanPhams.ToList();
            _lstGioHangs = _context.gioHangs.ToList();
            _lstGioHangchitiet = _context.gioHang_ChiTiets.ToList();
            _lstaddGioHangs = (from a in _lstGioHangs
                              join b in _lstGioHangchitiet on a.MaGioHang equals b.MaGioHang
                              join c in _lstSanPhams on b.MaSanPham equals c.MaSanPham
                            
                              select new AddGioHang()
                              {
                                  gioHang=a,
                                  gioHang_ChiTiet = b,
                                  sanPham = c,
                                 


                              }).ToList();

            return _lstaddGioHangs;
        }

     

        [HttpPost]
        public IActionResult Create(GioHang gioHang, string id)
        {
          


            for (int i = 0; i < _lstGioHangs.Count; i++)
            {
                if (_lstGioHangs[i].TrangThaiHD == false)
                {
                  
                    var spgh = _lstGioHangchitiet.Where(c => c.MaGioHang == _lstGioHangs[i].MaGioHang && c.MaSanPham==id).Select(c => c.MaSanPham).FirstOrDefault();
                    var update_giohang = _lstGioHangchitiet.FirstOrDefault(c => c.MaGioHang == _lstGioHangs[i].MaGioHang);
                    if (spgh==id)
                    {
                        var dongia = _lstSanPhams.Where(c => c.MaSanPham == id).Select(c => c.GiaBan).FirstOrDefault();
                        var update_sanPham_gioHang = _lstGioHangchitiet.FirstOrDefault(c => c.MaGioHang == _lstGioHangs[i].MaGioHang&&c.MaSanPham==id);
                        update_sanPham_gioHang.soluong += 1;
                        update_sanPham_gioHang.Thanhtien = update_sanPham_gioHang.soluong * dongia;
                        _context.Update(update_sanPham_gioHang);
                        _context.SaveChangesAsync();
                    }
                    else
                    {
                        update_giohang.MaGioHang = _lstGioHangs[i].MaGioHang;
                        update_giohang.MaSanPham = id;
                        var dongia = _lstSanPhams.Where(c => c.MaSanPham == id).Select(c => c.GiaBan).FirstOrDefault();
                        update_giohang.DonGia = dongia;
                        update_giohang.soluong = 1;
                        update_giohang.Thanhtien = update_giohang.soluong * dongia;
                        update_giohang.TrangThai = true;
                        _context.gioHang_ChiTiets.Add(update_giohang);
                        _context.SaveChangesAsync();
                    }
                    
                  

                }
                else
                {
                    _giohang.MaGioHang = "GH" + (_lstGioHangs.Count() + 1).ToString();
                    _giohang.MaKhachHang = "kh01";
                    _giohang.ThoiGian = DateTime.Now;
                    //  int giabansp = _listsanphams.where(c => c.masanpham == id).select(c => c.giaban).firstordefault();
                    _giohang.TongTien = 0; //viewGioHangs().Where(c => c.gioHang.MaGioHang == _giohang.MaGioHang).Sum(c => c.gioHang_ChiTiet.Thanhtien);
                    _giohang.GhiChu = null;
                    _giohang.TrangThaiHD = false;
                    _context.Add(_giohang);
                    _context.SaveChangesAsync();

                    _gioHang_ChiTiet.MaGioHang = _giohang.MaGioHang;
                    _gioHang_ChiTiet.MaSanPham = id;
                    var dongia = _lstSanPhams.Where(c => c.MaSanPham == id).Select(c => c.GiaBan).FirstOrDefault();
                    _gioHang_ChiTiet.DonGia = dongia;
                    _gioHang_ChiTiet.soluong = 1;
                    _gioHang_ChiTiet.Thanhtien = _gioHang_ChiTiet.soluong * dongia;
                    _gioHang_ChiTiet.TrangThai = true;
                    _context.Add(_gioHang_ChiTiet);
                    _context.SaveChangesAsync();

                }
            }



            return RedirectToAction(nameof(Index));


        }
        public IActionResult Delete()
        {
            return View();
        }

    }
}
