using IdentityItI.Database;
using IdentityItI.Models;
using IdentityItI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityItI.Controllers
{
    [Authorize(Roles="Admin")]
    public class LessonController : Controller
    {
        private readonly DataBaseConnection context;

        public LessonController(DataBaseConnection context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddLesson(int id)
        {

            var course = this.context.Courses.Find(id);
                var lessons = this.context.Lessons.Where(l => l.courseId == id).ToList();
            CourseLesson cl = new CourseLesson() {
                lessons = lessons,
               course=course
                
                };
         
            
            
           
            return View(cl);

        }



        [HttpPost]
        public IActionResult AddLesson(Lesson lesson)
        {
            lesson.Id=0;

            this.context.Lessons.Add(lesson);
            this.context.SaveChanges();
            var course = this.context.Courses.Find(lesson.courseId);
            var lessons = this.context.Lessons.Where(l => l.courseId == lesson.courseId).ToList();
            CourseLesson cl = new CourseLesson()
            {

                lessons = lessons,
                course=course



            };

            return View(cl);

        }

        [HttpPost]
        public IActionResult Edit(Lesson l) {
            var lesson = this.context.Lessons.Find(l.Id);
            lesson.LessonVideo = l.LessonVideo;
            lesson.Title = l.Title;


            this.context.SaveChanges();

            return RedirectToAction("AddLesson", new {id=l.courseId });

        
        }


      


    }
}
