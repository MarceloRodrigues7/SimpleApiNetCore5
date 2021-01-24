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
        // GET users
        public IEnumerable<Users> GetUser()
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = ("SELECT id, name, '******' as 'password',statusAccount,dateCreate FROM users");
            var res = connection.Query<Users>(query);
            return res;
        }
        // POST new user
        public IEnumerable<Users> PostNewUser(Users users)
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = ("INSERT INTO users(name,password,statusAccount) VALUES (@name,@password,@statusAccount)");
            var res = connection.Query<Users>(query, new { users.name, users.password, users.statusAccount });
            return res;
        }
        // DELETE user Where ID
        public IEnumerable<Users> DeleteUser(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = ("DELETE FROM users where id=@id");
            var res = connection.Query<Users>(query, new { id });
            return res;
        }
        // UPDATE Status Account
        public IEnumerable<Users> Put_StatusUser(int id, int status)
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = ("UPDATE users SET statusAccount=@status WHERE id=@id");
            var res = connection.Query<Users>(query, new { id, status });
            return res;
        }
    }
}
