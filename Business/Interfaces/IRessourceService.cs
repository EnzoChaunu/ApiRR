using Commun.dto;
using Commun.Responses;
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
        public Task<Response<bool>> AddView(string id);
        public Task<Response<bool>> ShareRessource(int ress,string token,string destinataireEmail);
        public Task GetJob();
        public Task<Response<List<JobDto>>> GetJobForFront(string secteurActivite);
        public Task<Response<dynamic>> GetRessource(string reference);
        public Task GetFormation();
        public Task<Response<UserfavoriteRessourceDto>> AddFavorite(string token,int ressource);
        public void RefreshCache ();
        public Task<Response<List<AlternanceDto>>> GetFormationForFront(string romeDomain,string departement);
        public Task<Response<List<RessourceDto>>> GetListRessourceByUser(string token);


    }
}
