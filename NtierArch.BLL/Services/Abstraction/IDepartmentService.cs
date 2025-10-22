namespace NtierArch.BLL.Services.Abstraction
{
    public interface IDepartmentService
    {
        Response<bool> Add(CreateDepartmentVM department);
        Response<bool> Edit(UpdateDepartmentVM department);
        Response<bool> ToggleStatus(int id);
        Response<GetDepartmentVM> GetDepartment(int id);
        Response<List<GetDepartmentVM>> GetActiveDepartments();
        Response<List<GetDepartmentVM>> GetNotActiveDepartments();
    }

}
