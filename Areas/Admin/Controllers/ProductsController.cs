using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShope.Data;
using OnlineShope.Models;
using Microsoft.AspNetCore.Hosting;

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
        
        public async Task<IActionResult> Create(Products products, IFormFile Image)
        {
            if(ModelState.IsValid)
            {
                if(Image != null)
                {
                    var name = Path.Combine(_he.WebRootPath+ "/Upload", Path.GetFileName(Image.FileName));
                    await Image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Img = "Upload/" + Image.FileName;
                }
                _db.Pruducts.Add(products);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);

        }
       
    }
}
