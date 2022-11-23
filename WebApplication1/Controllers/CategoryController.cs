using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        #region DependencyInjection
        private readonly NorthwindContext _db;

        public CategoryController(NorthwindContext db)
        {
            _db = db;
        }
        #endregion

        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _db.Categories.Select(c => new { c.CategoryId, c.Description, c.CategoryName }).ToList() });
        }



        public IActionResult Create()
        {

            return View();
        }

        //Data Annotation
        [HttpPost]
        public IActionResult Create(Category category)
        {



            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");

        }



        [HttpPost]
        public IResult Edit(int categoryId, string description, string categoryName)
        {

            Category foundCat = _db.Categories.Find(categoryId);
            foundCat.CategoryName = categoryName;
            foundCat.Description = description;
            _db.SaveChanges();
            return Results.Accepted(categoryId + " ID'li kategori Duzenleme işlemi başarıyla tamamlanmıştır");
        }

        [HttpPost]
        public IResult Delete(int categoryId)
        {

            Category cat = _db.Categories.Find(categoryId);
            _db.Categories.Remove(cat);
            _db.SaveChanges();

            return Results.Ok(categoryId + " ID'li kategori Silme işlemi başarıyla tamamlanmıştır");
        }


        [HttpPost]
        public IActionResult GetById(int categoryId)
        {
            Category cat = _db.Categories.Find(categoryId);
            return Json(cat);
        }
    }
}
