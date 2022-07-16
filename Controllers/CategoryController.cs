using CategoryMVC.Data;
using CategoryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> obj = _db.CategoryList;

            return View(obj);
        }

        //Get create
        [HttpGet]
        public IActionResult Create()
        {
            

            return View();
        }
        [HttpGet]
        public IActionResult Edit( int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.CategoryList.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //Post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj )
        {
            if (ModelState.IsValid)
            {
                _db.CategoryList.Add(obj); // Adding to Table obj which was created in ApplicationDBConext
                _db.SaveChanges();    // saving the Database
                return RedirectToAction("Index"); // to redirect to CategoryList
            }
            else return View(obj);
        }

    }
}
