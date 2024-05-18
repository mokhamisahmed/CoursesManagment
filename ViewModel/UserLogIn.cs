using System.ComponentModel.DataAnnotations;

namespace IdentityItI.ViewModel
{
    public class UserLogIn
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }




    }
}
