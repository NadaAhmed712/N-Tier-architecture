namespace NtierArch.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        bool Add(Employee employee);
        bool Edit(Employee employee);
        bool ToggleStatus(string id, string UserName);
        Employee GetEmployeeById(string id);
        List<Employee> GetAll(Expression<Func<Employee,bool>>?Filter=null);
    }
}
