using NtierArch.BLL.ModelVM.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierArch.BLL.Services.Abstraction
{
    public interface IAccountService
    {
        Task<Response<bool>> RegisterUser(RegisterEmployeeVM model);
    }
}
