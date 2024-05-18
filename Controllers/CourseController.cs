using IdentityItI.Database;
using IdentityItI.Models;
using IdentityItI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
namespace IdentityItI.Controllers
{
    [Authorize(Roles="Admin")]
    public class CourseController : Controller
    {

        private readonly DataBaseConnection context;

        private readonly IWebHostEnvironment webHostEnvironment;

        public CourseController(DataBaseConnection context, IWebHostEnvironment webHostEnvironment) {

            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course) {
            var c = this.context.Courses.Find(course.Id);
            c.Name = course.Name;
            c.Description = course.Description;

          
            if (c.Image!=course.Image) {
                c.Image = await this.UploadFile(course.file);
                this.DeleteFile(c.Image);
            }
            
           
           await this.context.SaveChangesAsync();
            return RedirectToAction("AddCourse");
        }


        [HttpGet]
        public IActionResult AddCourse()
        {
            CourseCategory courseCategory = new CourseCategory() { 
            categories=this.context.Categories.ToList(),
            Courses=this.context.Courses.Include(c=>c.category).ToList()
            };
            return View(courseCategory);
        
        }
        [HttpPost]

        public async Task<IActionResult> AddCourse(Course course)
        {


          course.Image= await this.UploadFile(course.file);
            this.context.Courses.Add(course);
            await this.context.SaveChangesAsync();
            CourseCategory courseCategory = new CourseCategory()
            {
                categories = this.context.Categories.ToList(),
                Courses = this.context.Courses.Include(c => c.category).ToList()
            };
            return View(courseCategory); 
            
        }

       

        [HttpGet]
        public IActionResult Get_Course()
        {


            return View();
        }
        [HttpPost]

        public IActionResult Delete(int id) {

            var course=this.context.Courses.Find(id);



            this.context.Courses.Remove(course);

            this.DeleteFile(course.Image);

            this.context.SaveChanges();

            return RedirectToAction("AddCourse");
        }

       







       








        private async Task<String> UploadFile(IFormFile file) {
            string fileName = null;
            if (file!=null)
            {
                string UploadDir = Path.Combine(this.webHostEnvironment.WebRootPath,"Images");

                fileName = Guid.NewGuid().ToString() + "." + file.FileName;

                    String FilePath = Path.Combine(UploadDir, fileName);

                using (var fileStream = new FileStream(FilePath, FileMode.Create)) {

                   await file.CopyToAsync(fileStream);
                    return "/Images/" + fileName;
                }
               

            }

            return null;
        
        }

        public int DeleteFile(String imageName) {
            if (!string.IsNullOrEmpty(imageName))
            {
                string filePath = Path.Combine(this.webHostEnvironment.WebRootPath, "Images", imageName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                    return 1;
                }
            }

            return 0;


        }





    }
}
