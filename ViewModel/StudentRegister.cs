using System.ComponentModel.DataAnnotations;

namespace IdentityItI.ViewModel
{
    public class StudentRegister
    {

        [Required]
        public String UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public String Password { get; set; }

    }
}
