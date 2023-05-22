using Commun.Responses;
using RRelationnelle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        public bool CheckEmail(string email);
        public Task<Response<UserDto>> UpdateUserToken(int user, Response<string> token);
        public Task<Response<List<UserDto>>> GetUserListByRole(string role);
        public Task<Response<List<UserDto>>> GetAll();
    }
}
