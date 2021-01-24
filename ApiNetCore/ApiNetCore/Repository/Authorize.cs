using System.Collections.Generic;
using System.Linq;
using ApiNetCore.Domain;

namespace ApiNetCore.Repository
{
    public class Authorize
    {
        //TokenApi
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "apinetcore", Password = "pass123", Role = "manager" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}