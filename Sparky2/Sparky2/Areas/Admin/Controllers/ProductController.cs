using Microsoft.AspNetCore.Mvc;
using Sparky2.DataAccess.Repository.IRepository;
using Sparky2.Models.Models;

namespace Sparky2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
       
            private readonly IUnitOfWork _unitOfWork;
            public ProductController(IUnitOfWork db)
            {
                _unitOfWork = db;
            }
            public IActionResult Index()
            {
                List<Product> products = _unitOfWork.ProductRepository.GetAll().ToList();
                return View();
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Product p)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.ProductRepository.Add(p); //add to database
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
                Product? p = _unitOfWork.ProductRepository.Get(u => u.Id == id); //finds through primary key
                if (p == null) return NotFound();
                return View(p);
            }
            [HttpPost]
            public IActionResult Edit(Product p)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.ProductRepository.Update(p); //add to database
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
                Product? p = _unitOfWork.ProductRepository.Get(u => u.Id == id); //finds through primary key
                if (p == null) return NotFound();
                return View(p);
            }
            [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id)
            {
                Product? p = _unitOfWork.ProductRepository.Get(u => u.Id == id); //finds through primary key
                if (p == null) return NotFound();
                _unitOfWork.ProductRepository.Remove(p); //remove from database
                _unitOfWork.Save(); //save changes to database
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index"); //go back to Index Action to reload the categories list in the view
            }
        }
    }
