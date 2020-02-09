using vm = SocialEvents.ViewModel;
using SocialEvents.Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    public interface ISafeerService
    {
        vm.Employee GetEmployeeInfo(string empLogin);
        List<Department> GetDepartments();
    }

    public class SafeerService : ISafeerService
    {
        private readonly SafeerServiceRef.SafeerServiceClient safeerService;
        public SafeerService()
        {
            safeerService = new SafeerServiceRef.SafeerServiceClient();
        }

        public vm.Employee GetEmployeeInfo(string empLogin)
        {

            empLogin = empLogin.Replace("\\\\", "\\");
            var empnum = safeerService.GetEmpIDByNTLogin(NTLogin: empLogin);
            var empInfo = safeerService.GetEmployeeByEmployeeNumber(empnum);

            if (empInfo != null && !string.IsNullOrEmpty(empInfo.FullName))
            {
                vm.Employee employee = new vm.Employee();
                employee.Department = empInfo.DepartmentNameAr;
                employee.EnDepartment = empInfo.DepartmentName;
                employee.Email = empInfo.EmailAddress;
                employee.EnName = empInfo.FullName;
                employee.Name = empInfo.FullNameAr;
                employee.Mobile = empInfo.Mobile;
                employee.DepartmentID = empInfo.DepartmentID;
                employee.EmployeeNo = empInfo.EmployeeNo;
                employee.LoginName = empInfo.LoginName;

                return employee;
            }


            return null;
        }


        public List<Department> GetDepartments()
        {
            var safeerDepts = safeerService.GetAllDepartments();
            var result = safeerDepts.Select(e => new Department
            {
                DepartmentID = e.DepartmentID,
                DepartmentNameEn = e.DepartmentNameEn,
                DepartmentNameAr = e.DepartmentNameAr
            }
            ).ToList();

            return result;
        }

      
    }
}
