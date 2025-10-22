namespace NtierArch.BLL.Services.Impelementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            this.mapper = mapper;
        }
        public Response<List<GetEmployeeVM>> GetActiveEmployees()
        {
            try
            {
                var result = employeeRepo.GetAll(e => e.IsDeleted == false);
                var resultVM= mapper.Map<List<GetEmployeeVM>>(result);
                return new Response<List<GetEmployeeVM>>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<List<GetEmployeeVM>>(null, ex.Message, true);

            }
        }

        public Response<List<GetEmployeeVM>> GetNotActiveEmployees()
        {
            try
            {
                var result = employeeRepo.GetAll(e => e.IsDeleted == true);
                var resultVM = mapper.Map<List<GetEmployeeVM>>(result);

                return new Response<List<GetEmployeeVM>>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<List<GetEmployeeVM>>(null, ex.Message, true);

            }
        }


        public Response<GetEmployeeVM> GetEmployee(int id)
        {
            try
            {
                var result = employeeRepo.GetEmployeeById(id);
                if(result==null)

                    return new Response<GetEmployeeVM>(null, "There is no Employee with this Id", true);
                var resultVM = mapper.Map<GetEmployeeVM>(result);

                return new Response<GetEmployeeVM>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<GetEmployeeVM>(null, ex.Message, true);

            }
        }

        public Response<bool> Add(CreateEmployeeVM employee)
        {
            try
            {
                string image = Upload.UploadFile("Files", employee.Image);
                var emp = new Employee(employee.Name, employee.Age, employee.Salary, image, employee.DeptId, "Nada Ahmed");
                var result= employeeRepo.Add(emp);
                if (result)
                    return new Response<bool>(true, null, false);
                else
                    return new Response<bool>(false, "there is an error", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);

            }
            
        }

        public Response<bool> Edit(UpdateEmployeeVM employee)
        {
            try
            {
                employee.UpdatedBy = "Nada Ahmed";

                var map = mapper.Map<Employee>(employee);

                string image = Upload.UploadFile("Files", employee.Image);
                if (image!=null)
                {
                    var oldEmp = employeeRepo.GetEmployeeById(employee.Id);
                    if (!string.IsNullOrEmpty(oldEmp.Image))
                    {
                        Upload.RemoveFile("Files", oldEmp.Image);
                    }
                    oldEmp.UpdateImage(image, employee.UpdatedBy);
                }
                var flag=employeeRepo.Edit(map);
                if (flag)
                    return new Response<bool>(true, null, false);
                else
                    return new Response<bool>(false, "Failed to update employee.", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);
            }
        }

        public Response<bool> ToggleStatus(int id)
        {
            try
            {
                var result = employeeRepo.ToggleStatus(id, "Nada Ahmed");
                if (result)
                    return new Response<bool>(true, null, false);

                return new Response<bool>(false, "Failed to change employee status.", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);
            }
        }
    }
}
