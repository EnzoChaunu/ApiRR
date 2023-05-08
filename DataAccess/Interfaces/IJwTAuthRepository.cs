using System.Collections.Generic;
using System.Threading.Tasks;
using RRelationnelle;

namespace DataAccess.Interfaces
{
    public interface IJwTAuthRepository
    {
      Task<List<User>> GetUsers();
    }
}
