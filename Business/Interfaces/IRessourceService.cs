using Commun.dto;
using RRelationnelle;
using RRelationnelle.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRessourceService : IService<RessourceDto>
    {
        public Task<bool> AddView(int id);
        public Task<List<JobDto>> GetJob(string secteurActivite, string departement);
        public Task<List<AlternanceDto>> GetFormation(string rome, string romeDomain, string caller, string departement);

    }
}
