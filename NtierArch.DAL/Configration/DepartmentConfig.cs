namespace NtierArch.DAL.Configration
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Area)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(d => d.employees)
                   .WithOne(e => e.Department)
                   .HasForeignKey(e => e.DeptId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
