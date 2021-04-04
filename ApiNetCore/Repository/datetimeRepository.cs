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
    public sealed class datetimeRepository : IDatetimeRepository
    {
        /// <summary>
        /// Method return values for objects class datetime
        /// </summary>
        /// <returns>Date,DateTime,Time</returns>
        public dateTime Get_DateTime()
        {
            dateTime dateTime = new dateTime();
            dateTime.Date = DateTime.Now.ToString("dd/MM/yyyy");
            dateTime.DateHour = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            dateTime.Hour = Hour();
            return dateTime;
        }

        public string Hour()
        {
            var hour = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
            return hour;
        }

    }
}
