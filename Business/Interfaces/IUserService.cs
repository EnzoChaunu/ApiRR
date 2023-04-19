using Commun.Responses;
using RRelationnelle;

namespace Business.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        public bool CheckEmail(string email);
    }
}
