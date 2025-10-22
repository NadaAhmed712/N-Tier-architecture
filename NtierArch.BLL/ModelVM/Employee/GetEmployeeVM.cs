using System;
using System.Collections.Generic;
using System.Linq;
namespace NtierArch.BLL.ModelVM.Employee
{
    public class GetEmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }
        public string? Image { get; set; }

        //public bool IsDeleted { get; set; }
    }
}
