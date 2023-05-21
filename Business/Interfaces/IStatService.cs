using Commun.Responses;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IStatService : IService<StatsDto>
    {
        public Task<Response<StatsDto>> GetStat();
    }
}
