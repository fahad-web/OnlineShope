using Microsoft.AspNetCore.Mvc;
using OnlineShope.Data;
using OnlineShope.Models;

namespace OnlineShope.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpacialTagController : Controller
    {
        private ApplicationDbContext _db;
        public SpacialTagController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SpacialTags.ToList());
        }

        // Create Get Action Method
        public ActionResult Create()
        {
            return View();
        }

        // Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpacialTag spacialTag)
        {
            if (ModelState.IsValid)
            {
                _db.SpacialTags.Add(spacialTag);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product Add Succesfully";
                return RedirectToAction("Index");
            }
            return View(spacialTag);
        }
    }
}
