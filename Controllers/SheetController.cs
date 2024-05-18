using IdentityItI.Database;
using IdentityItI.Models;
using IdentityItI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityItI.Controllers
{
    [Authorize(Roles="Admin")]
    public class SheetController : Controller
    {
        private readonly DataBaseConnection context;

        private readonly IWebHostEnvironment webHostEnvironment;

        public SheetController(DataBaseConnection context, IWebHostEnvironment webHostEnvironment)
        {

            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]

        public IActionResult AddSheet(int id)
        {
            var lesson = this.context.Lessons.Find(id);
            LessonSheet lessonSheet = new LessonSheet()
            {
                lesson=lesson,
                sheets = this.context.Sheets.Include(s => s.lesson).Where(s=>s.lessonId==id).ToList()
            };

            return View(lessonSheet);

        }

        [HttpPost]
        public async Task<IActionResult> AddSheet(Sheet sheet) {
            sheet.Id=0;

           
            this.context.Sheets.Add(sheet);

            this.context.SaveChanges();




            var lesson = this.context.Lessons.Find(sheet.lessonId);
            LessonSheet lessonSheet = new LessonSheet() {

                sheets = this.context.Sheets.Include(s => s.lesson).Where(s=>s.lessonId==lesson.Id).ToList(),

                lesson = lesson
            };

            return View(lessonSheet);
        


        }

        [HttpPost]

        public IActionResult Delete(Sheet s) {
            var sheet = this.context.Sheets.Find(s.Id);

            this.context.Sheets.Remove(sheet);

            this.context.SaveChanges();

            return RedirectToAction("AddSheet", new { id = s.lessonId });
        
        }



        [HttpPost]
        public IActionResult EditSheetLesson(Sheet s) {
            var sheet = this.context.Sheets.Find(s.Id);
            sheet.Path = s.Path;
            sheet.Name = s.Name;
            this.context.SaveChanges();
            return RedirectToAction("AddSheet", new {id=s.lessonId });
        
        }

   


    }
}
