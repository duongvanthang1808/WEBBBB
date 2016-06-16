
using baitapCNPM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapCNPM.Areas.Admin.Models;

namespace baitapCNPM.Common
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.UserName))
            {
                filterContext.Result = new RedirectToRouteResult(new
               System.Web.Routing.RouteValueDictionary(new
               {
                   Controller = "Login",
                   Action = "Index"
               }));
            }
            else
            {
                var am = new LoginDao().getUsers();
                CustomPrincipal cp = new CustomPrincipal(am.Find(m => m.username.Trim() == SessionPersister.UserName));
                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                        (new
                   {
                       Controller = "Login",
                       Action = "Index"
                   }));

                }
            }
        }
    }
}