using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SocialEvents.Web.Helpers
{
    public static class UserConfigurationExtensions
    {
        public static bool HasAnyRoles(this IPrincipal User, string roles)
        {
            bool result = false;
            var selectedRoles = roles.Split(',');
            var sessionRoles = (List<string>)HttpContext.Current.Session["user-roles"];
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
            var sessionRoles = (List<string>)HttpContext.Current.Session["user-roles"];
            if (sessionRoles != null && sessionRoles.Any())
            {
                result = selectedRoles.All(r => sessionRoles.Contains(r));
            }

            return result;
        }
    }
}