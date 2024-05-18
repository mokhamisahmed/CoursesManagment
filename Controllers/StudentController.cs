using IdentityItI.Database;
using IdentityItI.Models;
using IdentityItI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityItI.Controllers
{

    public class StudentController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signManager;
       
        private readonly DataBaseConnection context;
        public StudentController(DataBaseConnection context,  UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signManager = signInManager;
            this.context = context;
           

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

   
        public IActionResult SignUp() {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(StudentRegister u)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = u.UserName;
                user.Email = u.Email;
              

                var result = await this.userManager.CreateAsync(user, u.Password);


                if (result.Succeeded)
                {
                  
                        await this.userManager.AddToRoleAsync(user,"Student");

                    await this.signManager.SignInAsync(user, false);


                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError(null, error.Description);

                    }

                }


                return View();

            }
            return View();


          
        }

       



    }
}
