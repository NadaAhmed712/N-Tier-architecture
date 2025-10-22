using NtierArch.BLL.ModelVM.Employee;

namespace NtierArch.BLL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, GetEmployeeVM>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeVM>().ReverseMap();
            CreateMap<Department, GetDepartmentVM>().ReverseMap();
            CreateMap<Department, UpdateDepartmentVM>().ReverseMap();
        }
    }
}
