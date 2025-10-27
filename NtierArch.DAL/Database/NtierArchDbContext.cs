using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NtierArch.DAL.Database
{
    public class NtierArchDbContext:IdentityDbContext
    {
        public NtierArchDbContext(DbContextOptions<NtierArchDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-GQ2PFB2\\MSSQLSERVER06;Database=NtierArch;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
