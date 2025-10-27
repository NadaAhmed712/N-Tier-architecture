using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NtierArch.BLL.Helper;
using NtierArch.BLL.ModelVM.Account;
using NtierArch.BLL.Services.Impelementation;
using NtierArch.DAL.Entity;
using static System.Net.Mime.MediaTypeNames;

namespace NtierArch.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly IAccountService accountService;
        private readonly SignInManager<Employee> signInManager;
        private readonly UserManager<Employee> userManager;

        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, IDepartmentService departmentService, IAccountService accountService)
        {
            this.userManager = userManager;
            this.departmentService = departmentService;
            this.accountService = accountService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            ViewBag.departments = departmentService.GetActiveDepartments();
            return View();
        }
        [HttpPost]
        //public async Task<IActionResult> Register(RegisterEmployeeVM model)
        //{
        //    if (!ModelState.IsValid)
        //        return View("Register", model);
        //    var result = await accountService.RegisterUser(model);

        //    if (result.IsHaveError==false)
        //    {
        //        return RedirectToAction("Login");
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {

        //            ModelState.AddModelError("Password", error);
        //        }
        //        return View(model);
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.departments = departmentService.GetActiveDepartments();
                return View("Register", model);
            }
            string image = Upload.UploadFile("Files", model.Image);
            var user = new Employee(model.Name, model.Age, model.Salary, image, model.DeptId, "Nada Ahmed", model.UserName);
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginEmployeeVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName Or Password");

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
