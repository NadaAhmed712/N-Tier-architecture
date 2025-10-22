namespace NtierArch.BLL.ModelVM.Department
{
    public class UpdateDepartmentVM: CreateDepartmentVM
    {
        public int Id { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
