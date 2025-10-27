namespace NtierArch.BLL.ModelVM.Employee
{
    public class UpdateEmployeeVM:CreateEmployeeVM
    {
        public string Id { get; set; }
        public string? UpdatedBy {  get; set; }
    }
}
