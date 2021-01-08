using ApiNetCore.Domain;
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
