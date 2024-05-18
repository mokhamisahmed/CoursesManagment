namespace IdentityItI.Models
{
    public class Lesson
    {

        public int Id { get; set; }

        public String Title{ get; set; }

        public String LessonVideo { get; set; }
        public int courseId { get; set; }
      public Course course { get; set; }

        public List<Sheet> Sheets { get; set; }
    
    
    }
}
