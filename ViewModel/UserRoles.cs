using IdentityItI.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityItI.ViewModel
{
    public class UserRoles
    {

        public List<IdentityRole> Roles { get; set; }

        public dynamic userRoles { get; set; }

        public UserRegister user { get; set; }


    }
}
