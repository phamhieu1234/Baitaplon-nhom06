using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapLonNhom06.Models;
using BaiTapLonNhom06.Models.Process;

namespace BaiTapLonNhom06.Controllers
{
    public class PhongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phong
        public async Task<IActionResult> Index()
        {
              return _context.Phong != null ? 
                          View(await _context.Phong.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Phong'  is null.");
        }

        // GET: Phong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Phong == null)
            {
                return NotFound();
            }

            var phong = await _context.Phong
                .FirstOrDefaultAsync(m => m.PhongID == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // GET: Phong/Create
          private   StringProcess strPro = new StringProcess();
        public IActionResult Create()
        {
             var newphong = "P01"; //đặt tên
            var countphong = _context.Phong.Count(); //đếm số nhân viên 
            if (countphong  > 0)
            {
                var phong = _context.Phong.OrderByDescending(m => m.PhongID).First().PhongID;
                newphong  = strPro.AutoGenerateCode(phong);
            }
            ViewBag.newphong = newphong;
            return View();
        }

        // POST: Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhongID,TienPhong,CSVC")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phong);
        }

        // GET: Phong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Phong == null)
            {
                return NotFound();
            }

            var phong = await _context.Phong.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            return View(phong);
        }

        // POST: Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PhongID,TienPhong,CSVC")] Phong phong)
        {
            if (id != phong.PhongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.PhongID))
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
            return View(phong);
        }

        // GET: Phong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Phong == null)
            {
                return NotFound();
            }

            var phong = await _context.Phong
                .FirstOrDefaultAsync(m => m.PhongID == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Phong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Phong'  is null.");
            }
            var phong = await _context.Phong.FindAsync(id);
            if (phong != null)
            {
                _context.Phong.Remove(phong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(string id)
        {
          return (_context.Phong?.Any(e => e.PhongID == id)).GetValueOrDefault();
        }
    }
}
