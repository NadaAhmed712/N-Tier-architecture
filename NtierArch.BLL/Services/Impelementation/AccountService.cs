using Microsoft.AspNetCore.Identity;
using NtierArch.BLL.ModelVM.Account;
using NtierArch.DAL.Entity;
using NtierArch.DAL.Repo.Impelementation;

namespace NtierArch.BLL.Services.Impelementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Employee> userManger;

        public AccountService(UserManager<Employee> userManger)
        {
            this.userManger = userManger;
        }

        public async Task<Response<bool>> RegisterUser(RegisterEmployeeVM model)
        {

            try
            {
                string image = Upload.UploadFile("Files", model.Image);
                var user = new Employee(model.Name, model.Age, model.Salary, image, model.DeptId, "Nada Ahmed", model.UserName);
                var result = await userManger.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return new Response<bool>(true, null, false);
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
