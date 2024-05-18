using IdentityItI.Models;

namespace IdentityItI.ViewModel
{
    public class LessonSheet
    {

        public Lesson lesson { get; set; }

        public List<Sheet> sheets { get; set; }

        public Sheet sheet { get; set; }
    }
}
