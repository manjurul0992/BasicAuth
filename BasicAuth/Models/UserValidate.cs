using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth.Models
{
    public class UserValidate
    {
        public static bool Login(string username, string password)
        {
            UserBL userbl = new UserBL();
            var userLists=userbl.GetUsers();
            return userLists.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }
    }
}