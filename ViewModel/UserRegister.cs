using System.ComponentModel.DataAnnotations;

namespace IdentityItI.ViewModel
{
    public class UserRegister
    {
        [Required]
        public String UserName { get; set; }
       
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public String Password { get; set; }

        public String roleId { get; set; }

            
       
    }
}
