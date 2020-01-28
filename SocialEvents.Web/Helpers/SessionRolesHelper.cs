using Beneficiary.BL.BusinessHandlers;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beneficiary.Web.Helpers
{
    public class SessionRolesHelper
    {
        internal static void FillSessionWithSacabUserRoles(HttpContext current, SacabHandler sacabHandler)
        {
            string userName = current.Request.LogonUserIdentity.Name.Split('\\')[1];
            var sessionRoles = (List<string>)current.Session["user-roles"];
            if (sessionRoles == null || !sessionRoles.Any())
            {
                List<string> userRoles = sacabHandler.GetUserRolesByUserName(userName).Select(e => e.SecurityRoleCode).ToList();
                current.Session["user-roles"] = userRoles;
            }
        }
    }
}