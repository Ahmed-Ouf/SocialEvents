using SocialEvents.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vm=SocialEvents.ViewModel;

namespace Beneficiary.Web.Helpers
{
    public class SessionRolesHelper
    {
   

        internal static void FillSessionWithSacabUserRoles(HttpContext current, ISessionService sessionService)
        {

            //EX, current.Request.LogonUserIdentity.Name = "RCJNT2\\ABDELAZIZAUFA"
            string empLogin = current.Request.LogonUserIdentity.Name;

            var sessionUserInfo = (vm.CurrentUserViewModel)current.Session["current-user"];

            if (sessionUserInfo == null)
            {
                current.Session["current-user"] = sessionService.GetCurrentUserInfo(empLogin);
            }
        }
    }
}