using ApiNetCore.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

        /// <summary>
        /// Return all Users to table users 
        /// </summary>
        /// <returns>id,name,passwor in HEX, statusAccount,dateCreate</returns>
        public IEnumerable<Users> GetUser()
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = "SELECT id, name, HEX(password)as 'password',statusAccount,dateCreate FROM users";
            var res = connection.Query<Users>(query);
            return res;
        }

        /// <summary>
        /// Method create new Users
        /// </summary>
        /// <param name="users">name,password,statusAccount</param>
        /// <returns>New Users</returns>
        public IEnumerable<Users> PostNewUser(Users users)
        {
            using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM users WHERE name=@name";
            var exec = connection.Query<Users>(query, new { users.name });
            if (exec.FirstOrDefault() == null)
            {
                query = "INSERT INTO users(name,password,statusAccount) VALUES (@name,@password,@statusAccount)";
                connection.Query<Users>(query, new { users.name, users.password, users.statusAccount });
                query = "SELECT id, name, HEX(password)as 'password',statusAccount,dateCreate FROM users WHERE name=@name";
                var res = connection.Query<Users>(query, new { users.name });
                return res;
            }
            else
            {
                var res = UsersEmpty();
                return res;
            }
        }
        
        public IEnumerable<Users> DeleteUser(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            
            var query = "Select * from users where id=@id";
            var res = connection.Query<Users>(query, new { id });
            if(res.Count() == 0)
            {
                res = UsersEmpty();
                return res;
            }
            else
            {
                query = "DELETE FROM users where id=@id";
                res = connection.Query<Users>(query, new { id });
                return res;
            }
        }

        /// <summary>
        /// Return new IEnumerable Users null
        /// </summary>
        /// <returns>New Users Empty</returns>
        public IEnumerable<Users> UsersEmpty()
        {         
            IEnumerable<Users> userNull = new List<Users>
            {
            new Users { id=1,name=null,password=null,statusAccount=0,dateCreate=null}
            };
            return userNull;
        }
    }
}
