using ApiNetCore.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Repository
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataServer");
        }
        //TokenApi
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "apinetcore", Password = "pass123", Role = "manager" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }

        public IEnumerable<Users> GetUser()
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = ("SELECT id, name, '******' as 'password',statusAccount,dateCreate FROM users");
            var res = connection.Query<Users>(query);
            return res;
        }
        public IEnumerable<Users> PostNewUser(Users users)
        {
            using var connection = new MySqlConnection(_connectionString);

            var queryValid = ("SELECT count(name) as id from users where name=@name");
            var execValid = connection.Query<Users>(queryValid, new { users.name });
            
            if (execValid.Count() == 0)
            {
                var query = ("INSERT INTO users(name,password,statusAccount) VALUES (@name,@password,@statusAccount)");
                var res = connection.Query<Users>(query, new { users.name, users.password, users.statusAccount });
                return res;
            }
            else
            {
                var query=("");
                var res = connection.Query<Users>(query);
                return res;
            }
        }
        public IEnumerable<Users> DeleteUser(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = ("DELETE FROM users where id=@id");
            var res = connection.Query<Users>(query, new { id });
            return res;
        }
    }
}
