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
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Client.Include(c => c.GioiTinh);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.GioiTinh)
                .FirstOrDefaultAsync(m => m.KhachhangID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Create
         private   StringProcess strPro = new StringProcess();
        public IActionResult Create()
        {
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh");
            var newclient = "NV01"; //đặt tên
            var countclient = _context.Client.Count(); //đếm số nhân viên 
            if (countclient  > 0)
            {
                var KhachhangID = _context.Client.OrderByDescending(m => m.KhachhangID).First().KhachhangID;
                newclient  = strPro.AutoGenerateCode(KhachhangID);
            }
            ViewBag.newID = newclient;
            var newsophong = "SP01"; //đặt tên
            var countSophong = _context.Client.Count(); //đếm số nhân viên 
            if (countSophong  > 0)
            {
                var sophong = _context.Client.OrderByDescending(m => m.Sophong).First().Sophong;
                newsophong  = strPro.AutoGenerateCode(sophong);
            }
            ViewBag.newsophong = newsophong;
            return View();
            
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhachhangID,Ten,MaGioiTinh,Address,SĐT,CMND,Sophong,Ngayra,Ngayvao")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh", client.MaGioiTinh);
            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh", client.MaGioiTinh);
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KhachhangID,Ten,MaGioiTinh,Address,SĐT,CMND,Sophong,Ngayra,Ngayvao")] Client client)
        {
            if (id != client.KhachhangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.KhachhangID))
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
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh", client.MaGioiTinh);
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.GioiTinh)
                .FirstOrDefaultAsync(m => m.KhachhangID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Client'  is null.");
            }
            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                _context.Client.Remove(client);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(string id)
        {
          return (_context.Client?.Any(e => e.KhachhangID == id)).GetValueOrDefault();
        }
    }
}
