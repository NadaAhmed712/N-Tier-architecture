namespace NtierArch.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        bool Add(Employee employee);
        bool Edit(Employee employee);
        bool ToggleStatus(int id, string UserName);
        Employee GetEmployeeById(int id);
        List<Employee> GetAll(Expression<Func<Employee,bool>>?Filter=null);
    }
}
