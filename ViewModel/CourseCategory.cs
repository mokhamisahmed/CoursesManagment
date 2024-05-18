using IdentityItI.Models;

namespace IdentityItI.ViewModel
{
    public class CourseCategory
    {

        public Course course { get; set; }

        public List<Category> categories { get; set; }

        public List<Course> Courses { get; set; }
    }
}
