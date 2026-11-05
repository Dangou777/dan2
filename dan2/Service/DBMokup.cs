using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dan2.Model;

namespace dan2.Service
{

        public class DBMokup
        {
            private List<AppUser> _users = new List<AppUser>();
            public DBMokup()
            {
                _users.Add(new AppUser { UserEmail = "admin@mail.com", UserPassword = "admin" });
                _users.Add(new AppUser { UserEmail = "user1@mail.com", UserPassword = "pass1" });
                _users.Add(new AppUser { UserEmail = "user2@mail.com", UserPassword = "pass2" });
            }
            public bool isExist(string uEmail, string uPass)
            {
                return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
            }
        }
}
