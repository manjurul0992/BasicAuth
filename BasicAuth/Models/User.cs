using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserBL
    {
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            userList.Add(new User()
            {
                Id = 1,
                UserName = "Manjurul",
                Password = "1234"
            });
            userList.Add(new User()
            {
                Id = 2,
                UserName = "Syed",
                Password = "4321"
            });
            return userList;
        }
    }
}