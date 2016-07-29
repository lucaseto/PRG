using PRDGSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PRDGSTest.Security
{
    public class PRDGSPrincipal : IPrincipal
    {
        private Account Account;
        private AccountModel am = new AccountModel();

        public PRDGSPrincipal(string userName)
        {
            this.Identity = new GenericIdentity(userName);
            this.Account = am.Find(userName);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.Roles.Contains(r));
        }
    }
}