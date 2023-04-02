using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRelationnelle.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
            
        }

        public Task<bool> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Create(UserDto obj)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Update(UserDto obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
