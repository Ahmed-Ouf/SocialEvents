using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using vm=SocialEvents.ViewModel;
namespace SocialEvents.Web.Helpers
{
    public static class UserConfigurationExtensions
    {
        public static bool HasAnyRoles(this IPrincipal User, string roles)
        {
            bool result = false;
            var selectedRoles = roles.Split(',');
            var currentUserInfo= (vm.CurrentUserViewModel)HttpContext.Current.Session["current-user"];
            var sessionRoles = currentUserInfo?.Roles;
            if (sessionRoles != null && sessionRoles.Any())
            {
                result = selectedRoles.Any(r => sessionRoles.Contains(r));
            }

            return result;
        }

        public static bool HasAllRoles(this IPrincipal User, string roles)
        {
            bool result = false;
            var selectedRoles = roles.Split(',');
            var currentUserInfo = (vm.CurrentUserViewModel)HttpContext.Current.Session["current-user"];
            var sessionRoles = currentUserInfo.Roles;
            if (sessionRoles != null && sessionRoles.Any())
            {
                result = selectedRoles.All(r => sessionRoles.Contains(r));
            }

            return result;
        }
    }
}