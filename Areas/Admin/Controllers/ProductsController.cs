using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShope.Data;
using OnlineShope.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace OnlineShope.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db; 

        private IWebHostEnvironment _he;
        public ProductsController(ApplicationDbContext db, IWebHostEnvironment he)
        {
            _db = db; 
            _he = he;
        }

        public IActionResult Index()
        {
            return View(_db.Pruducts.Include(c=>c.SpacialTag).Include(c=>c.productType).ToList());
        }
        //Get  Action Method
        public IActionResult Create()
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(),"Id", "ProductTypes");
            ViewData["SpacialTagId"] = new SelectList(_db.SpacialTags.ToList(), "Id", "Condition");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Products products, IFormFile? Image)
        {
            if(ModelState.IsValid)
            {
                var searchProduct = _db.Pruducts.FirstOrDefault(c => c.Name == products.Name);
                if(searchProduct != null)
                {
                    ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductTypes");
                    ViewData["SpacialTagId"] = new SelectList(_db.SpacialTags.ToList(), "Id", "Condition");
                    ViewBag.message = "This Product already Exist";
                    return View(products);
                }
                if(Image != null)
                {
                    var name = Path.Combine(_he.WebRootPath+ "/Upload", Path.GetFileName(Image.FileName));
                    await Image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Img = "Upload/" + Image.FileName;
                }
                _db.Pruducts.Add(products);
                await _db.SaveChangesAsync();
                TempData["Save"] = "Product Add Succesfully";
                return RedirectToAction("Index");
            }
            return View(products);

        }

        //Get Action Method
        public IActionResult Edit(int? id)
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductTypes");
            ViewData["SpacialTagId"] = new SelectList(_db.SpacialTags.ToList(), "Id", "Condition");
            if(id == null)
            {
                return NotFound();
            }
            var products = _db.Pruducts.Include(c => c.SpacialTag).Include(c=>c.productType).FirstOrDefault(c=> c.Id==id);
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Products products, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _db.Pruducts.FirstOrDefault(c => c.Name == products.Name && c.Id != products.Id); //c.Id != products.Id this means when i check Product name mach or not but this Product id not check 
                if (searchProduct != null)
                {
                    ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductTypes");
                    ViewData["SpacialTagId"] = new SelectList(_db.SpacialTags.ToList(), "Id", "Condition");
                    ViewBag.message = "This Product already Exist";
                    return View(products);
                }
                if (Image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Upload", Path.GetFileName(Image.FileName));
                    await Image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Img = "Upload/" + Image.FileName;
                }
                _db.Pruducts.Update(products);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);

        }

        //Get Action Method for View
        public IActionResult Details(int? id)
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductTypes");
            ViewData["SpacialTagId"] = new SelectList(_db.SpacialTags.ToList(), "Id", "Condition");
            if (id == null)
            {
                return NotFound();
            }
            var products = _db.Pruducts.Include(c => c.SpacialTag).Include(c => c.productType).FirstOrDefault(c => c.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        //Get Action Method For Delete
        public IActionResult Delete(int? id)
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductTypes");
            ViewData["SpacialTagId"] = new SelectList(_db.SpacialTags.ToList(), "Id", "Condition");
            if (id == null)
            {
                return NotFound();
            }
            var products = _db.Pruducts.Include(c => c.SpacialTag).Include(c => c.productType).FirstOrDefault(c => c.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Products products, int? id)
        {
            if (ModelState.IsValid)
            {
                if(id== null)
                {
                    return NotFound();
                }
                if(products== null)
                {
                    return NotFound();
                }
                if(id != products.Id)
                {
                    return NotFound();
                }
                _db.Pruducts.Remove(products);
                await _db.SaveChangesAsync();
                TempData["Delete"] = "Product Deleted";
                return RedirectToAction("Index");
            }
            return View(products);

        }
        //Filtering Product with Price
        //Using Post Action Mathod
        [HttpPost]
        public IActionResult Index(decimal? lowPrice, decimal? highPrice)
        {
            var products = _db.Pruducts.Include(c => c.productType).Include(c => c.SpacialTag).Where(c => c.Price >= lowPrice && c.Price <= highPrice).ToList();
            if(lowPrice == null || highPrice == null)
            {
                products = _db.Pruducts.Include(c => c.productType).Include(c => c.SpacialTag).ToList();
                
            }
            if (products.Count == 0)
            {
                TempData["Message"] = "No products found.";
            }
            return View(products);
        }
    }
}
