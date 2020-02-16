using vm = SocialEvents.ViewModel;
using System.Linq;

namespace SocialEvents.Service
{
    public interface ISessionService
    {
        vm.CurrentUserViewModel GetCurrentUserInfo(string empLogin);
    }

    public class SessionService : ISessionService
    {
        private readonly ISafeerService safeerService;
        private readonly ISacabService sacabService;
        private readonly IDepartmentService departmentService;
        public SessionService(ISacabService _sacabService, ISafeerService _safeerService, IDepartmentService _departmentService)
        {
            sacabService = _sacabService;
            safeerService = _safeerService;
            departmentService = _departmentService;
        }

        public vm.CurrentUserViewModel GetCurrentUserInfo(string empLogin)
        {
            string sacabUserName = empLogin.Split('\\')[1];
            var safeerEmployee = safeerService.GetEmployeeInfo(empLogin);
            var sacabUserRoles = sacabService.GetUserRolesByUserName(sacabUserName);
            var roles = sacabUserRoles.Select(e => e.SecurityRoleCode).ToList();

            //TODO: Remove comments
#if !DEBUG 
            //var department = departmentService.GetBySafeerDepartmentId(safeerEmployee?.DepartmentID);
            //if (department == null)
            //{
            //    return null;
            //}
#endif

            var currentUser = new vm.CurrentUserViewModel
            {
                SafeerDepartmentId = safeerEmployee?.DepartmentID,
                LoginName = safeerEmployee?.LoginName,
                Roles = roles
            };
            return currentUser;
        }





    }
}
