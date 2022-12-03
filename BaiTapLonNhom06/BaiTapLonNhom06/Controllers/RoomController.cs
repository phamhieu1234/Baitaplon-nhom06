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
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Room.Include(r => r.GiaPhong);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(r => r.GiaPhong)
                .FirstOrDefaultAsync(m => m.RommID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Room/Create
         private   StringProcess strPro = new StringProcess();
        public IActionResult Create()
        {
            ViewData["MaGiaPhong"] = new SelectList(_context.GiaPhong, "MaGiaPhong", "MaGiaPhong");
             var newroom = "MP100"; //đặt tên
            var countroom = _context.Room.Count(); //đếm số nhân viên 
            if (countroom  > 0)
            {
                var Mancc = _context.Room.OrderByDescending(m => m.RommID).First().RommID;
                newroom  = strPro.AutoGenerateCode(Mancc);
            }
            ViewBag.newID = newroom;
            return View();
            
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RommID,MaGiaPhong,CSVC")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGiaPhong"] = new SelectList(_context.GiaPhong, "MaGiaPhong", "MaGiaPhong", room.MaGiaPhong);
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["MaGiaPhong"] = new SelectList(_context.GiaPhong, "MaGiaPhong", "MaGiaPhong", room.MaGiaPhong);
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RommID,MaGiaPhong,CSVC")] Room room)
        {
            if (id != room.RommID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RommID))
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
            ViewData["MaGiaPhong"] = new SelectList(_context.GiaPhong, "MaGiaPhong", "MaGiaPhong", room.MaGiaPhong);
            return View(room);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(r => r.GiaPhong)
                .FirstOrDefaultAsync(m => m.RommID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Room == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Room'  is null.");
            }
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(string id)
        {
          return (_context.Room?.Any(e => e.RommID == id)).GetValueOrDefault();
        }
    }
}
