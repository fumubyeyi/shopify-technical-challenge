using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopifyTechnicalChallenge.Models;

namespace ShopifyTechnicalChallenge.Controllers
{
    public class HomeController : BaseController
    {

        private readonly InventoryContext _context;

        public HomeController(InventoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Inventory.ToListAsync());
        }

        public JsonResult LoadData()
        {
            var list = _context.Inventory.ToList();
            return Json(new { data = list});
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await GetCategories();

            return View(new Inventory());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory model)
        {

            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.Categories = await GetCategories();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Inventory item = await _context.Inventory.FirstOrDefaultAsync(i => i.Id == id);

            ViewBag.Categories = await GetCategories();

            return View(item);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Inventory model)
        {
            Inventory item = await _context.Inventory.FindAsync(model.Id);

            if (ModelState.IsValid)
            {
                try
                {
                    item.Name = model.Name;
                    item.Description = model.Description;
                    item.Category = model.Category;
                    item.Price = model.Price;
                    item.Quantity = model.Quantity;

                    _context.Update(item);                   
                
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }

            ViewBag.Categories = await GetCategories();
            return View(model);

        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            Inventory inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Inventory inventory = await _context.Inventory.FindAsync(id);
             _context.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult Export()
        {
            var inventoryList = _context.Inventory.ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id,Name,Description,Category,Price,Quantity");

            foreach (var data in inventoryList)
            {
                sb.AppendLine($"{data.Id},{data.Name},{data.Description},{data.Category},{data.Price},{data.Quantity}");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Inventory.csv");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<List<SelectListItem>> GetCategories()
        {
            List<SelectListItem> categories = await _context.Category.Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            }).ToListAsync();

            categories.Insert(0, new SelectListItem() { Value = "", Text = "Select Category"});

            return categories;
        }




    }

  
}
