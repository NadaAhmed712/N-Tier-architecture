namespace NtierArch.DAL.Repo.Abstraction
{
    public interface IDepartmentRepo
    {
        bool Add(Department department);
        bool Edit(Department department);
        bool ToggleStatus(int id, string UserName);
        Department GetDepartmentById(int id);
        List<Department> GetAll(Expression<Func<Department, bool>>?Filter=null);
    }
}
