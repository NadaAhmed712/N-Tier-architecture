using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NtierArch.BLL.ModelVM.Role;

namespace NtierArch.PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {

            var getRoleByName = await RoleManager.FindByNameAsync(roleVM.Name); //Admin
            if (getRoleByName is not { })
            {
                var role = new IdentityRole() { Name = roleVM.Name };
                var result = await RoleManager.CreateAsync(role);
                return RedirectToAction("Index","Home");
            }


            return View(roleVM);
        }
    }
}
