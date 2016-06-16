using baitapCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace baitapCNPM.Common
{
    public class CustomPrincipal : IPrincipal
    {
        private user user;
        private role role;
        public CustomPrincipal(user user)
        {
            this.user = user;
            this.Identity = new GenericIdentity(user.username);
            this.role = new shopDBModel().roles.Where(m => m.roleID == user.role_id).FirstOrDefault();
        }
        public IIdentity Identity { get; set; }
        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.role.role1.Contains(r));
        }

    }
}