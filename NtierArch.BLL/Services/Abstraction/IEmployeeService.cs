using NtierArch.BLL.ModelVM.Employee;

namespace NtierArch.BLL.Services.Abstraction
{
    public interface IEmployeeService
    {
        Response<bool> Add(CreateEmployeeVM employee);
        Response<bool> Edit(UpdateEmployeeVM employee);
        Response<bool> ToggleStatus(int id);
        Response<GetEmployeeVM> GetEmployee(int id);
        Response<List<GetEmployeeVM>> GetActiveEmployees();
        Response<List<GetEmployeeVM>> GetNotActiveEmployees();
    }
}

