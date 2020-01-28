using Beneficiary.BL.BusinessHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beneficiary.Web.Helpers
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        private LoginAuditHandler loginAuditHandler;
        public RoleAuthorizeAttribute()
        {
            loginAuditHandler = new LoginAuditHandler();

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
         {
            SacabHandler sacabHandler = new SacabHandler();
            SessionRolesHelper.FillSessionWithSacabUserRoles(System.Web.HttpContext.Current, sacabHandler);

            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //if not logged, it will work as normal Authorize and redirect to the Login
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                //logged and without the role to access it - redirect to the custom controller action
                filterContext.Result = new RedirectResult("~/AuthraizedError.html"); ;
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;
            var selectedRoles = Roles.Split(',');
            var sessionRoles = (List<string>)httpContext.Session["user-roles"];
            if (sessionRoles != null && sessionRoles.Any())
            {
                result = selectedRoles.Any(r => sessionRoles.Contains(r) && true);
            }
            LogLoginData(result, httpContext);
            return result;
        }

        private void LogLoginData(bool authorized, HttpContextBase httpContext)
        {
            var audit = new Beneficiary.Models.LoginAudit();
            var request = httpContext.Request;
            if (authorized)
            {
                audit.AuthorizedStatus = "Authorized User";
            }
            else
            {
                audit.AuthorizedStatus = "Not Authorized User";

            }

            Stream req = request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            // audit.Data = json;
            audit.RequestMethod = request.HttpMethod;
            audit.BrowserInfo = request.UserAgent;
            audit.Url = request.Url.AbsoluteUri;
            audit.LoginDate = DateTime.Now;
            audit.UserName = httpContext.User.Identity.Name;

            loginAuditHandler.Add(audit);
        }
    }
}