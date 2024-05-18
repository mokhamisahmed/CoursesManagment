using IdentityItI.Models;
using IdentityItI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityItI.Controllers
{
    public class AccController : Controller
    {
       private readonly SignInManager<ApplicationUser> signManager;
        private readonly UserManager<ApplicationUser> userManager;
        public AccController(SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager)
        {
            this.signManager = signManager;
            this.userManager=userManager;
        }
        [HttpGet]

        public IActionResult LogIn()
        {

            return View();

        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.signManager.SignOutAsync();

            return RedirectToAction("LogIn");


        }

        [HttpPost]

        public async Task<IActionResult> LogIn(UserLogIn ul)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await this.userManager.FindByEmailAsync(ul.Email);

                if (user != null)
                {
                    bool isCorrect = await this.userManager.CheckPasswordAsync(user, ul.Password);

                    if (isCorrect)
                    {

                        await this.signManager.SignInAsync(user, false);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "password invalid");
                        return View(ul);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "username and password invalid");
                    return View(ul);
                }



            }

            return View(ul);


        }


    }
}
