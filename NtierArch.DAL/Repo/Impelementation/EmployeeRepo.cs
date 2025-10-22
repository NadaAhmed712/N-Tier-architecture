namespace NtierArch.DAL.Repo.Impelementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly NtierArchDbContext _context;
        public EmployeeRepo(NtierArchDbContext context)
        {
            _context = context;
        }
        public bool Add(Employee employee)
        {
            try
            {
                var result = _context.Employees.Add(employee);
                _context.SaveChanges();
                if (result.Entity.Id>0)
                    return true;
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Edit(Employee employee)
        {
            try
            {
                var result = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
                if (result != null)
                {
                    bool flag = result.Update(employee.Name, employee.Age, employee.Salary, employee.DeptId, employee.UpdatedBy);
                    if(flag)
                        _context.SaveChanges();
                    return flag;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>>? Filter = null)
        {
            try
            {
                if(Filter != null)
                {
                    var result = _context.Employees.Where(Filter).ToList();
                    return result;
                }
                else
                {
                    var result = _context.Employees.ToList();
                    return result;
                }
                
            }
            catch (Exception) {
                throw;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                var result = _context.Employees.FirstOrDefault(e=>e.Id==id);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ToggleStatus(int id, string UserName)
        {
            try
            {
                var result = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (result != null)
                {
                    bool flag = result.ToggalStatus(UserName);
                    if (flag)
                        _context.SaveChanges();
                    return flag;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
