using RRelationnelle;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        public Task<User> GetByEmail(string email);

    }
}
