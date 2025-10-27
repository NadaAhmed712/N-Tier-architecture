using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierArch.BLL.ModelVM.Account
{
    public class RegisterEmployeeVM
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public int DeptId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
