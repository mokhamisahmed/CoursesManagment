using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityItI.Models
{
    public class Sheet
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Path {get;set;}
       public int lessonId { get; set; }
        public Lesson lesson { get; set; }

    }
}
