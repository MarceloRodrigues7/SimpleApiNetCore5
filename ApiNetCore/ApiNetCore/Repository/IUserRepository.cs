using ApiNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Repository
{
    public interface IUserRepository
    {
        public IEnumerable<Users> GetUser();
        public IEnumerable<Users> PostNewUser(Users users);
        public IEnumerable<Users> DeleteUser(int id);
    }
}
