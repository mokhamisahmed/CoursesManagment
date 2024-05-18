using IdentityItI.Models;

namespace IdentityItI.ViewModel
{
    public class CourseLesson
    {
        public Course course { get; set; }
       
        public List<Lesson> lessons { get; set; }

        public Lesson lesson { get; set; }


    }
}
