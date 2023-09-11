using Microsoft.AspNetCore.Mvc;
using OnlineShope.Data;
using OnlineShope.Models;
using System.Drawing.Text;
using static System.Collections.Specialized.BitVector32;

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
                var searchProdutType = _db.ProductTypes.FirstOrDefault(c => c.ProductTypes==productType.ProductTypes);
                if(searchProdutType != null)
                {
                    ViewBag.message = "ProductType already Exist";
                    return View(productType);
                }
                _db.ProductTypes.Add(productType);  
                await _db.SaveChangesAsync();
                TempData["save"] = "Product Add Succesfully";
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
                var searchProdutType = _db.ProductTypes.FirstOrDefault(c => c.ProductTypes == productType.ProductTypes);
                if (searchProdutType != null)
                {
                    ViewBag.message = "ProductType already Exist";
                    return View(productType);
                }
                _db.Update(productType);
                await _db.SaveChangesAsync();
                TempData["update"] = "Product Update Succesfully";
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


        // Delete Get Action Method
        public ActionResult Delete(int? id)
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

        // Delete Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete( int? id, ProductType productType)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (productType == null)
            {
                return NotFound();
            }
            if(id != productType.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Product Delete Succesfully";
                return RedirectToAction("Index");
            }
            return View(productType);
        }

    }
}