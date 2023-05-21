using Commun.Responses;
using RRelationnelle;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IStatsRepo : IRepository<Stats>
    {
        public Task<Response<Stats>> GetStat();
    }
}
