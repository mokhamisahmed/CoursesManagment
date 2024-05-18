using IdentityItI.Database;
using IdentityItI.Models;
using IdentityItI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IdentityItI.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DataBaseConnection context;
        public AccountController(DataBaseConnection context,RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager) {
            this.userManager = userManager;
            this.signManager = signInManager;
            this.context = context;
            this.roleManager = roleManager;
           
        }



        [HttpGet]
        public IActionResult SignUp() {

            UserRoles userRoles = new UserRoles() { 
            Roles = this.roleManager.Roles.ToList(),
            userRoles=this.UsersRoles()

        };
           
            return View(userRoles);
        }
        

        public IActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> SignUp(UserRegister u)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = u.UserName;
                user.Email = u.Email;
               
               var result= await this.userManager.CreateAsync(user,u.Password);
             
               
                if (result.Succeeded)
                {
                    var RoleName = roleManager.Roles.SingleOrDefault(r => r.Id == u.roleId);
                    if (RoleName != null)
                    {
                       await  this.userManager.AddToRoleAsync(user, RoleName.Name);
            
                    }

                    UserRoles userRoles = new UserRoles()
                    {
                        Roles = this.roleManager.Roles.ToList(),
                        userRoles= this.UsersRoles()
                    };
                    return View(userRoles);
                }
                else {
                    foreach (var error in result.Errors) {

                        ModelState.AddModelError(null,error.Description);

                    }
                
                }
               

                return View();

            }
            return View();

        }

        private dynamic UsersRoles() {

            var userRoles = (from userRole in context.UserRoles
                                  join user in context.Users on userRole.UserId equals user.Id
                                  join role in context.Roles on userRole.RoleId equals role.Id
                                  select new
                                  {
                                      UserId = user.Id,
                                      UserName = user.UserName,
                                      Email=user.Email,
                                      RoleId = role.Id,
                                      RoleName = role.Name
                                  }).ToList();

            return userRoles;



        }



        
        
        [HttpGet]
        public IActionResult Logout()
        {
            this.signManager.SignOutAsync();

            return RedirectToAction("LogIn");


        }
        
        
       
        [HttpGet]
        public IActionResult Contact() {

            return View();
        }


        [HttpGet] 

        public IActionResult GetUsers()
        {

            var users = this.userManager.Users.ToList();

            return Content("test");
        }


    }
}
