using System.Collections.Generic;
using System.Linq;
using ApiNetCore.Domain;

namespace ApiNetCore.Repository
{
    public class Authorize
    {
        /// <summary>
        /// Method validation users and return token to Controllers 
        /// </summary>
        /// <param name="username">User Token</param>
        /// <param name="password">Pass Token</param>
        /// <returns></returns>
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "apinetcore", Password = "pass123", Role = "manager" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}