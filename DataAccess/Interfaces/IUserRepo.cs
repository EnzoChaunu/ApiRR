using RRelationnelle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        public Task<User> GetByEmail(string email);
        public Task<User> GetUserByToken(string token);
        public Task<User> UpdateUserToken(int user,string token);
        public Task<int> CountAccounts();
        public Task<List<User>> GetUserListByRole(string role);

    }
}
