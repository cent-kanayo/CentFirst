using CentFirst.Data;
using CentFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentFirst.Controllers
{
    public class CategoryController : Controller
    {

        private readonly DbConfig _db;
        public CategoryController(DbConfig db) {
            _db = db;
        }
        public IActionResult Index()
        
        {
            List<Category> objCategories = _db.Categories.ToList();
            return View(objCategories);
        }
        
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj) 
        {
            if(obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("", "Name cannot be the same as Display Order");           
            }
          if (ModelState.IsValid){
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id < 1)
            {
                return NotFound();  
            }
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if(ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {

            Category? category = _db.Categories.Find(id);

            if (category == null)
            {
                return View();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");

        }
    }
}
