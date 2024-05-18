namespace IdentityItI.Models
{
    public class CourseRegistration
    {
        public int Id { get; set; }
        public String userId { get; set; }
        public ApplicationUser user { get; set; }
        public int courseId { get; set; }
        public Course course { get; set; }


    }

}
