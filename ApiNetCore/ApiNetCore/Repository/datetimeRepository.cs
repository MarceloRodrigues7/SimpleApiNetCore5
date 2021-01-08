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
    public class datetimeRepository : IDatetimeRepository
    {
        private readonly string _connectionString;
        public datetimeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataServer");
        }
        public IEnumerable<dateTime> GetDateTime()
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = ("select date(now()) as 'Date' ,now() as 'dateHour', CONVERT(time(now()),NCHAR) as 'hour'");
            var res = connection.Query<dateTime>(query);
            return res;
        }
    }
}
