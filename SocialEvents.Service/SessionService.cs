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
        public SessionService(ISacabService _sacabService, ISafeerService _safeerService)
        {
            sacabService = _sacabService;
            safeerService = _safeerService;
        }

        public vm.CurrentUserViewModel GetCurrentUserInfo(string empLogin)
        {
            string sacabUserName = empLogin.Split('\\')[1];
            var safeerEmployee = safeerService.GetEmployeeInfo(empLogin);
            var sacabUserRoles = sacabService.GetUserRolesByUserName(sacabUserName);
            var roles = sacabUserRoles.Select(e => e.SecurityRoleCode).ToList();

            var currentUser = new vm.CurrentUserViewModel
            {
                DepartmentID = safeerEmployee?.DepartmentID,
                LoginName = safeerEmployee?.LoginName,
                Roles = roles
            };
            return currentUser;
        }





    }
}
