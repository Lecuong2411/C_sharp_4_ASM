using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5_6.Models;

namespace Lab5_6.Controllers
{
    public class HocSinhsController : Controller
    {
        private readonly NETMVCContext _context;

        public HocSinhsController(NETMVCContext context)
        {
            _context = context;
        }

        // GET: HocSinhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.HocSinhs.ToListAsync());
        }

        // GET: HocSinhs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocSinh = await _context.HocSinhs
                .FirstOrDefaultAsync(m => m.Msv == id);
            if (hocSinh == null)
            {
                return NotFound();
            }

            return View(hocSinh);
        }

        // GET: HocSinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HocSinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Msv,Ten,Dob,Diachi,Gioitinh,Sdt")] HocSinh hocSinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocSinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocSinh);
        }

        // GET: HocSinhs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocSinh = await _context.HocSinhs.FindAsync(id);
            if (hocSinh == null)
            {
                return NotFound();
            }
            return View(hocSinh);
        }

        // POST: HocSinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Msv,Ten,Dob,Diachi,Gioitinh,Sdt")] HocSinh hocSinh)
        {
            if (id != hocSinh.Msv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocSinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocSinhExists(hocSinh.Msv))
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
            return View(hocSinh);
        }

        // GET: HocSinhs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocSinh = await _context.HocSinhs
                .FirstOrDefaultAsync(m => m.Msv == id);
            if (hocSinh == null)
            {
                return NotFound();
            }

            return View(hocSinh);
        }
        public IActionResult Delete_name(string name)
        {
            List<HocSinh> hocSinhs;
            if (!string.IsNullOrWhiteSpace(name))
            {
                hocSinhs = _context.HocSinhs.Where(c => c.Ten.ToLower() == name).ToList();
            }
            else
            {
                hocSinhs = _context.HocSinhs.ToList();
            }


            return View(hocSinhs);
        }
        public async Task<IActionResult> Delete_city(string city)
        {
            List<HocSinh> hocSinhs;
            if (!string.IsNullOrWhiteSpace(city))
            {
                hocSinhs = _context.HocSinhs.Where(c => c.Diachi.ToLower() == city).ToList();
            }
            else
            {
                hocSinhs = _context.HocSinhs.ToList();
            }


            return View(hocSinhs);
        }
        // POST: HocSinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hocSinh = await _context.HocSinhs.FindAsync(id);
            _context.HocSinhs.Remove(hocSinh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete_name")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed_name(string name)
        {
            var b = _context.HocSinhs.Where(c => c.Ten == name).Count();
            for (int i = 0; i < b; i++)
            {
                var sv = _context.HocSinhs.Where(c => c.Ten == name).Select(c => c.Msv).FirstOrDefault();
                var hocSinh = await _context.HocSinhs.FindAsync(sv);
                _context.HocSinhs.Remove(hocSinh);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }
        [HttpPost, ActionName("Delete_city")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed_city(string city)
        {


            var hs = _context.HocSinhs.ToList();
            List<HocSinh> HocSinh = new List<HocSinh>();
            for (int i = 0; i < _context.HocSinhs.Count(); i++)
            {
                string tp = hs[i].Diachi.Split("-")[2].Trim();
                string cv = city;
                if (tp==city)
                {
                    HocSinh.Add(hs[i]);
                }
            }
            int count = HocSinh.Count();
            for (int i = 0; i < count; i++)
            {
                var id = HocSinh[i].Msv;
                
                var hocSinh = await _context.HocSinhs.FindAsync(id);
                _context.HocSinhs.Remove(hocSinh);
                await _context.SaveChangesAsync();
            }
         
           
           
            return RedirectToAction(nameof(Index));
        }

        private bool HocSinhExists(string id)
        {
            return _context.HocSinhs.Any(e => e.Msv == id);
        }
        public IActionResult timkiem(string name)
        {
            List<HocSinh> HocSinh;
            if (!string.IsNullOrWhiteSpace(name))
            {
                HocSinh = _context.HocSinhs.Where(c => c.Ten.Contains(name)).ToList();
            }
            else
            {
                HocSinh = _context.HocSinhs.ToList();
            }
            return View(HocSinh);


        }
    }
}
