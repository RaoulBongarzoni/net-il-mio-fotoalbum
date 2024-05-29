using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;


namespace net_il_mio_fotoalbum.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(PhotoManager.GetAllCategories()) ;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            PhotoManager.InsertCategory(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (PhotoManager.DeleteCategoryFromId(id))
                return RedirectToAction("Index");
            else
                return NotFound();
        }

    }
}
