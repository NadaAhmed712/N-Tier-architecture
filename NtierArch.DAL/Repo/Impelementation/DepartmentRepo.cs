namespace NtierArch.DAL.Repo.Impelementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly NtierArchDbContext _context;
        public DepartmentRepo(NtierArchDbContext context)
        {
            _context = context;
        }
        public bool Add(Department department)
        {
            try
            {
                var result = _context.Departments.Add(department);
                _context.SaveChanges();
                if (result.Entity.Id > 0)
                    return true;
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Edit(Department department)
        {
            try
            {
                var result = _context.Departments.FirstOrDefault(e => e.Id == department.Id);
                if (result != null)
                {
                    bool flag = result.Update(department.Name, department.Area, department.UpdatedBy);
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

        public List<Department> GetAll(Expression<Func<Department, bool>>? Filter = null)
        {
            try
            {
                if (Filter != null)
                {
                    var result = _context.Departments.Where(Filter).ToList();
                    return result;
                }
                else
                {
                    var result = _context.Departments.ToList();
                    return result;
                }
                
            }
            catch (Exception) {
                throw;
            }
        }

        public Department GetDepartmentById(int id)
        {
            try
            {
                var result = _context.Departments.FirstOrDefault(e=>e.Id==id);
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
                var result = _context.Departments.FirstOrDefault(e => e.Id == id);
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
