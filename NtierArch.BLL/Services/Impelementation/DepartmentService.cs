using AutoMapper;
using NtierArch.DAL.Repo.Abstraction;
using NtierArch.DAL.Repo.Impelementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierArch.BLL.Services.Impelementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo departmentRepo;
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepo departmentRepo, IMapper mapper)
        {
            this.departmentRepo = departmentRepo;
            this.mapper = mapper;
        }

        public Response<List<GetDepartmentVM>> GetActiveDepartments()
        {
            try
            {
                var result = departmentRepo.GetAll(e => e.IsDeleted == false);
                var resultVM = mapper.Map<List<GetDepartmentVM>>(result);
                return new Response<List<GetDepartmentVM>>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<List<GetDepartmentVM>>(null, ex.Message, true);

            }
        }

        public Response<List<GetDepartmentVM>> GetNotActiveDepartments()
        {
            try
            {
                var result = departmentRepo.GetAll(e => e.IsDeleted == true);
                var resultVM = mapper.Map<List<GetDepartmentVM>>(result);
                return new Response<List<GetDepartmentVM>>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<List<GetDepartmentVM>>(null, ex.Message, true);

            }
        }
        public Response<GetDepartmentVM> GetDepartment(int id)
        {
            try
            {
                var result = departmentRepo.GetDepartmentById(id);
                if (result == null)

                    return new Response<GetDepartmentVM>(null, "There is no Department with this Id", true);
                var resultVM = mapper.Map<GetDepartmentVM>(result);

                return new Response<GetDepartmentVM>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<GetDepartmentVM>(null, ex.Message, true);

            }
        }
        public Response<bool> Add(CreateDepartmentVM department)
        {
            try
            {
                
                var emp = new Department(department.Name, department.Area, "Nada Ahmed");
                var result = departmentRepo.Add(emp);
                if (result)
                    return new Response<bool>(true, null, false);
                else
                    return new Response<bool>(false, "there is an error", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);

            }
        }

        public Response<bool> Edit(UpdateDepartmentVM department)
        {
            try
            {
                department.UpdatedBy = "Nada Ahmed";

                var map = mapper.Map<Department>(department);

                var flag = departmentRepo.Edit(map);
                if (flag)
                    return new Response<bool>(true, null, false);
                else
                    return new Response<bool>(false, "Failed to update department.", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);
            }
        }

        public Response<bool> ToggleStatus(int id)
        {
            try
            {
                var result = departmentRepo.ToggleStatus(id, "Nada Ahmed");
                if (result)
                    return new Response<bool>(true, null, false);

                return new Response<bool>(false, "Failed to change department status.", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);
            }
        }
    }
}
