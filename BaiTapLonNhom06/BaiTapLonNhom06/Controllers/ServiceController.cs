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
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        //Tr ve view index danh sach
        public ServiceController (ApplicationDbContext context)
        {
            _context = context;
        }

        //Khai báo class ExcelProcess trong SẻvierController
        private ExcelProcess _excelProcess = new ExcelProcess();

        public async Task<IActionResult> Index()
        {
            var model = await _context.Service.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( Service sv)
        {
            if(ModelState.IsValid)
            {
                _context.Add(sv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
         // Kiểm tra DV theo id có tồn tai hay không
        private bool ServiceExists (string id)
        {
            return _context.Service.Any(e => e.ServiceID == id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return View("NotFound");
            }
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ServiceID,ServiceName,FoodName,DrinkName,HaircutName,Number,ServicePrice")]  Service sv)
        {
            if (id != sv.ServiceID)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(sv.ServiceID))
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sv);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return View("NotFound");
            }

            var sv = await _context.Service.FirstOrDefaultAsync(m => m.ServiceID == id);
            if (sv == null)
            {
                return View("NotFound");
            }

            return View(sv);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sv = await _context.Service.FindAsync(id);
            _context.Service.Remove(sv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data form dt
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Person object
                            var ser = new Service();
                            //set values for attribiutes
                            ser.ServiceID = dt.Rows[i][0].ToString();
                            ser.ServiceName = dt.Rows[i][1].ToString();
                            ser.FoodName = dt.Rows[i][2].ToString();
                            ser.DrinkName = dt.Rows[i][3].ToString();
                            ser.HaircutName = dt.Rows[i][4].ToString();
                            ser.Number = dt.Rows[i][5].ToString();
                            ser.ServicePrice = dt.Rows[i][6].ToString();
                            //add oject to context
                            _context.Service.Add(ser);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}