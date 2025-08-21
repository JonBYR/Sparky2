using Microsoft.AspNetCore.Mvc;
using Sparky2.DataAccess.Data;
using Sparky2.Models.Models;

namespace Sparky2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category c)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(c); //add to database
                _db.SaveChanges(); //save changes to database
                TempData["success"] = "Category created successfully"; //set a success message
                return RedirectToAction("Index"); //go back to Index Action to reload the categories list in the view
            }
            
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? c = _db.Categories.Find(id); //finds through primary key
            if (c == null) return NotFound();
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(Category c)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(c); //add to database
                _db.SaveChanges(); //save changes to database
                TempData["success"] = "Category updated successfully";
                //temp data will only stay for one request, refreshing the page will cleat the temp data
                return RedirectToAction("Index"); //go back to Index Action to reload the categories list in the view
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? c = _db.Categories.Find(id); //finds through primary key
            if (c == null) return NotFound();
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? c = _db.Categories.Find(id); //finds through primary key
            if (c == null) return NotFound();
            _db.Remove(c); //remove from database
            _db.SaveChanges(); //save changes to database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //go back to Index Action to reload the categories list in the view
        }
    }
}

