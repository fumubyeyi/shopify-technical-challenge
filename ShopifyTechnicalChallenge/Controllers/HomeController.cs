using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopifyTechnicalChallenge.Models;

namespace ShopifyTechnicalChallenge.Controllers
{
    public class HomeController : Controller
    {

        private readonly InventoryContext _context;

        public HomeController(InventoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Inventory.ToList());
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
    }
}
