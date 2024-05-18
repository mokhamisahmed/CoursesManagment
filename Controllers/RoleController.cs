using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityItI.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View(this.roleManager.Roles.ToList());

        }

        [HttpPost]

        public async Task<IActionResult> AddRole(IdentityRole role)
        {
           await  this.roleManager.CreateAsync(role);

            return View(this.roleManager.Roles.ToList());
        }

    }
}
