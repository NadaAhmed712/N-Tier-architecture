namespace NtierArch.DAL.Configration
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Age)
                   .IsRequired();

            builder.Property(e => e.Salary)
       .HasColumnType("decimal(18,2)");


            builder.HasOne(e => e.Department)
                   .WithMany(d => d.employees)
                   .HasForeignKey(e => e.DeptId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
