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
    public interface IDatetimeRepository
    {
        public IEnumerable<dateTime> GetDateTime();

    }
}
