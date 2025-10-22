namespace NtierArch.BLL.ModelVM.Employee
{
    public class UpdateEmployeeVM:CreateEmployeeVM
    {
        public int Id { get; set; }
        public string? UpdatedBy {  get; set; }
    }
}
