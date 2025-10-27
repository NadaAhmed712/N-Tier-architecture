using Microsoft.AspNetCore.Authorization;
using NtierArch.BLL.ModelVM.Department;

namespace NtierArch.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var result = departmentService.GetActiveDepartments();
            return View(result);
        }
        public IActionResult DeletedDepartment()
        {
            var result = departmentService.GetNotActiveDepartments();
            return View("Index",result);
        }
        [Authorize]
        public IActionResult GetDepartment(int id)
        {
            var result = departmentService.GetDepartment(id);
            return View(result);
        }
        [HttpGet]

        [Authorize(Roles ="User")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentVM department)
        {
            if (!ModelState.IsValid)
                return View("Create", department);

            departmentService.Add(department);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var response = departmentService.GetDepartment(id);
            var map = new UpdateDepartmentVM
            {
                Id = response.Result.Id,
                Name = response.Result.Name,
                Area = response.Result.Area
            };
            return View(map);
        }

        [HttpPost]
        public IActionResult Update(UpdateDepartmentVM department)
        {
            if (!ModelState.IsValid)
                return View("Update", department);
            departmentService.Edit(department);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            departmentService.ToggleStatus(Id);
            return RedirectToAction("Index");
        }
    }
}
