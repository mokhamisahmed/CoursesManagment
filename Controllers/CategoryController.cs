using IdentityItI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityItI.Models;

namespace IdentityItI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly DataBaseConnection context;

        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoryController(DataBaseConnection context, IWebHostEnvironment webHostEnvironment)
        {

            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View(this.context.Categories.ToList());

        }
        [HttpPost]
        public IActionResult Edit(Category c)
        {
            var category = this.context.Categories.Find(c.Id);
            category.Name = c.Name;
            this.context.SaveChanges();

            return RedirectToAction("AddCategory");
            

        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            this.context.Categories.Add(category);
            this.context.SaveChanges();

            return View(this.context.Categories.ToList());
        }
      

        [HttpPost]
        public IActionResult Delete(int id ) {

            var category = this.context.Categories.Find(id);

            this.context.Categories.Remove(category);

            this.context.SaveChanges();

            return RedirectToAction("AddCategory");


        }





    }
}
