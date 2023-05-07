using Commun.Responses;
using RRelationnelle;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        public bool CheckEmail(string email);
        public Task<Response<UserDto>> UpdateUserToken(int user,string token);
    }
}
