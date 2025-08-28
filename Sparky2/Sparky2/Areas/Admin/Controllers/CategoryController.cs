using Microsoft.AspNetCore.Mvc;
using Sparky2.DataAccess.Data;
using Sparky2.DataAccess.Repository.IRepository;
using Sparky2.Models.Models;

namespace Sparky2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();
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
                _unitOfWork.CategoryRepository.Add(c); //add to database
                _unitOfWork.Save(); //save changes to database
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
            Category? c = _unitOfWork.CategoryRepository.Get(u=>u.Id==id); //finds through primary key
            if (c == null) return NotFound();
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(Category c)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(c); //add to database
                _unitOfWork.Save(); //save changes to database
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
            Category? c = _unitOfWork.CategoryRepository.Get(u => u.Id == id); //finds through primary key
            if (c == null) return NotFound();
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? c = _unitOfWork.CategoryRepository.Get(u => u.Id == id); //finds through primary key
            if (c == null) return NotFound();
            _unitOfWork.CategoryRepository.Remove(c); //remove from database
            _unitOfWork.Save(); //save changes to database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //go back to Index Action to reload the categories list in the view
        }
    }
}

