using IdentityItI.Database;
using IdentityItI.ViewModel;
using IdentityItI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IdentityItI.Controllers
{
    [Authorize(Roles="Student")]
    public class RegistrationController : Controller
    {
        private readonly DataBaseConnection context;

        public RegistrationController(DataBaseConnection context) {

            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


       

        [HttpGet]

        public IActionResult GetSheets(Lesson lesson) {

            List<Sheet> sheets = this.context.Sheets.Where(l=>l.lessonId==lesson.Id).ToList();

            // Convert the list to JSON
            string json = JsonConvert.SerializeObject(sheets);

            // Return the JSON response with status code 200 (OK)
            return Ok(json);

        }


        [HttpPost]
        public IActionResult CourseRegistration(CourseRegistration cr) {

            this.context.Registrations.Add(cr);
         
            this.context.SaveChanges();
            return RedirectToAction("GetRegisterCourseLessons", new{ id=cr.courseId});
    
        
        }


        [HttpGet]
        public IActionResult GetCourses(int id)
        {



            var userId = @User.FindFirst(ClaimTypes.NameIdentifier).Value;



            List<test> coursesLists = (from c in context.Courses
                                       join cat in context.Categories on c.categoryId equals cat.Id
                                       where !context.Registrations.Any(r => r.userId == userId && r.courseId == c.Id)
                                       select new test
                                       {
                                           course = c,
                                           category = cat
                                       }).Where(c=>c.course.categoryId==id).ToList();
            if (coursesLists.Count == 0)
            {
                coursesLists.Add(
                    new test()
                    {
                        
                        category = this.context.Categories.Find(id),
                        isvalid = false,
                    }

                    );

            }



            return View(coursesLists);
        }


        [HttpGet]

        public IActionResult MyCourses(String id)
        {
            var courses = this.context.Registrations.Include(r => r.course).Where(r => r.userId == id).ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult GetCategories()
        {



            return View(this.context.Categories.ToList());

        }

        [HttpPost]
        public IActionResult GetCourseLessons(int id)
        {
            var lessons = this.context.Lessons.Include(ll => ll.course).Include(s => s.Sheets).Where(l => l.courseId == id).ToList();

            return View(lessons);

        }

        [HttpGet]

        public IActionResult GetRegisterCourseLessons(int id)
        {

            var lessons = this.context.Lessons.Include(ll => ll.course).Include(s => s.Sheets).Where(l => l.courseId == id).ToList();

            return View(lessons);

        }


    }
}
