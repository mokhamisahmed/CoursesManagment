using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityItI.Models
{
    public class Course
    {
        public int Id { get; set; }

        public String Name { get; set; }


        public String Description { get; set; }

        public String Image { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public List<Lesson> lessons { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }

        

    }
}
