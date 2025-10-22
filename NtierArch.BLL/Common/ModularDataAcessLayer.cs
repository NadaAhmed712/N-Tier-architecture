using NtierArch.BLL.Mapper;

namespace NtierArch.DAL.Common
{
    public static class ModularDataAcessLayer
    {
        public static IServiceCollection AddBusinessInBLL(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            return services;
        }
    }
}
