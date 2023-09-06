using Microsoft.AspNetCore.Mvc;
using OnlineShope.Data;
using OnlineShope.Models;
using System.Drawing.Text;

namespace OnlineShope.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext _db;
        public ProductTypeController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        // Create Get Action Method
        public ActionResult Create() 
        {
            return View();
        }

        // Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productType);  
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // Edit Get Action Method
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var producttype = _db.ProductTypes.Find(id);
            if (producttype == null)
            {
                return NotFound();
            }
            return View(producttype);
        }

        // Edit Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // Details Get Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttype = _db.ProductTypes.Find(id);
            if (producttype == null)
            {
                return NotFound();
            }
            return View(producttype);
        }

        // Details Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ProductType productType)
        {
            return View(productType);
        }

    }
}
