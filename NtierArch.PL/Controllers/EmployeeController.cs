namespace NtierArch.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var result=employeeService.GetActiveEmployees();
            return View(result);
        }
        public IActionResult DeletedEmployee()
        {
            var result = employeeService.GetNotActiveEmployees();
            return View(result);
        }
        public IActionResult GetEmployee(int id)
        {
            var result = employeeService.GetEmployee(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.departments = departmentService.GetActiveDepartments();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeVM employee)
        {
            if (!ModelState.IsValid)
                return View("Create", employee);

            employeeService.Add(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var response = employeeService.GetEmployee(id);
            //var map = mapper.Map<UpdateEmployeeVM>(response.Result);
            var map=new UpdateEmployeeVM
            {
                Id = response.Result.Id,
                Name = response.Result.Name,
                Salary = response.Result.Salary,
                DeptId = response.Result.DeptId
            };

            ViewBag.departments = departmentService.GetActiveDepartments();
            return View(map);
        }

        [HttpPost]
        public IActionResult Update(UpdateEmployeeVM employee)
        {
            if (!ModelState.IsValid)
                return View("Update", employee);
            employeeService.Edit(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            employeeService.ToggleStatus(Id);
            return RedirectToAction("Index");
        }
    }
}
