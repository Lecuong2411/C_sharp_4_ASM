using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASM.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ASM.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly QLBHContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SanPhamsController(QLBHContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var qLBHContext = _context.sanPhams.Include(s => s.danhMuc);
            return View(await qLBHContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPhams
                .Include(s => s.danhMuc)
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["MaDanhMuc"] = new SelectList(_context.danhMucs, "MaDoanhMuc", "MaDoanhMuc");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSanPham,TenSanPham,SoLuong,GiaBan,Ghichu,TrangThai,ImgFile,MaDanhMuc")] SanPham sanPham)
        {



            if (ModelState.IsValid)
            {

                string wwwRothPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(sanPham.ImgFile.FileName);
                string extension = Path.GetExtension(sanPham.ImgFile.FileName);
               sanPham.ImgName= filename = filename + DateTime.Now.ToString("ddMMyyyyy");
                string path = Path.Combine(wwwRothPath+"/images/",filename);
                using (var fileSteam = new FileStream(path, FileMode.Create)) {
                    await sanPham.ImgFile.CopyToAsync(fileSteam);
                }



                   _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDanhMuc"] = new SelectList(_context.danhMucs, "MaDoanhMuc", "MaDoanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["MaDanhMuc"] = new SelectList(_context.danhMucs, "MaDoanhMuc", "MaDoanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSanPham,TenSanPham,SoLuong,GiaBan,Ghichu,TrangThai,ImgName,MaDanhMuc")] SanPham sanPham)
        {
            if (id != sanPham.MaSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaSanPham))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDanhMuc"] = new SelectList(_context.danhMucs, "MaDoanhMuc", "MaDoanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPhams
                .Include(s => s.danhMuc)
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanPham = await _context.sanPhams.FindAsync(id);
            _context.sanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(string id)
        {
            return _context.sanPhams.Any(e => e.MaSanPham == id);
        }
    }
}
