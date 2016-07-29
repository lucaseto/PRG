using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRDGSTest.Models
{
    public class AccountModel
    {
        private List<Account> listAccounts = new List<Account>();

        public AccountModel() {
            listAccounts.Add(new Account() { UserName = "user1", Password = "123", Roles = new string[] { "admin", "reporter", "modifier" } });
            listAccounts.Add(new Account() { UserName = "user2", Password = "123", Roles = new string[] { "admin", "reporter", "modifier" } });
            listAccounts.Add(new Account() { UserName = "user3", Password = "123", Roles = new string[] { "rol1", "rol2" } });

        }

        public Account Find(string username)
        {
            return listAccounts.Single(acc => acc.UserName.Equals(username));
        }

        public Account Login(string username, string password)
        {
            return listAccounts.Where(acc => acc.UserName.Equals(username) && acc.UserName.Equals(password)).FirstOrDefault();
        }
    }
}