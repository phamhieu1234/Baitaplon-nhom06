using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapLonNhom06.Models;

namespace BaiTapLonNhom06.Controllers
{
    public class GiaPhongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiaPhongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GiaPhong
        public async Task<IActionResult> Index()
        {
              return _context.GiaPhong != null ? 
                          View(await _context.GiaPhong.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GiaPhong'  is null.");
        }

        // GET: GiaPhong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GiaPhong == null)
            {
                return NotFound();
            }

            var giaPhong = await _context.GiaPhong
                .FirstOrDefaultAsync(m => m.MaGiaPhong == id);
            if (giaPhong == null)
            {
                return NotFound();
            }

            return View(giaPhong);
        }

        // GET: GiaPhong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiaPhong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGiaPhong,TenGiaPhong")] GiaPhong giaPhong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaPhong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaPhong);
        }

        // GET: GiaPhong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GiaPhong == null)
            {
                return NotFound();
            }

            var giaPhong = await _context.GiaPhong.FindAsync(id);
            if (giaPhong == null)
            {
                return NotFound();
            }
            return View(giaPhong);
        }

        // POST: GiaPhong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaGiaPhong,TenGiaPhong")] GiaPhong giaPhong)
        {
            if (id != giaPhong.MaGiaPhong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaPhong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaPhongExists(giaPhong.MaGiaPhong))
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
            return View(giaPhong);
        }

        // GET: GiaPhong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GiaPhong == null)
            {
                return NotFound();
            }

            var giaPhong = await _context.GiaPhong
                .FirstOrDefaultAsync(m => m.MaGiaPhong == id);
            if (giaPhong == null)
            {
                return NotFound();
            }

            return View(giaPhong);
        }

        // POST: GiaPhong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GiaPhong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GiaPhong'  is null.");
            }
            var giaPhong = await _context.GiaPhong.FindAsync(id);
            if (giaPhong != null)
            {
                _context.GiaPhong.Remove(giaPhong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaPhongExists(string id)
        {
          return (_context.GiaPhong?.Any(e => e.MaGiaPhong == id)).GetValueOrDefault();
        }
    }
}
