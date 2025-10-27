using Microsoft.AspNetCore.Identity;
using NtierArch.BLL.ModelVM.Account;
using NtierArch.DAL.Entity;
using NtierArch.DAL.Repo.Impelementation;
using System.Data;

namespace NtierArch.BLL.Services.Impelementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Employee> userManager;

        public AccountService(UserManager<Employee> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Response<bool>> RegisterUser(RegisterEmployeeVM model)
        {

            try
            {
                string image = Upload.UploadFile("Files", model.Image);
                var user = new Employee(model.Name, model.Age, model.Salary, image, model.DeptId, "Nada Ahmed", model.UserName);
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var IsHaveRole = await userManager.IsInRoleAsync(user, "User");
                    if (!IsHaveRole)
                    {
                        var resultrole = await userManager.AddToRoleAsync(user, "User");
                    }
                    return new Response<bool>(true, null, false);
                }
                else
                {
                    return new Response<bool>(false, "there is an error", true, result.Errors.Select(e => e.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);

            }
        }
    }
}
