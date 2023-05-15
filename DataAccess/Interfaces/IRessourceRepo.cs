using Commun.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RRelationnelle;
using RRelationnelle.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRessourceRepo : IRepository<Ressource>
    {
      
        public Task<Ressource> GetRessourceById(string id);
        public Task<bool> ShareRessource(int id);
        public Task<ActionResult<bool>> Delete();
        public Task<int> AddView(string id);
        public Task<UserFavorite> CheckUserFavoriteByObject(User user,Ressource ressource);
        public Task<List<Ressource>> GetRessourceListUser(int user);
        public Task<UserFavorite> AddUserFavorite(UserFavorite fav);

    }
}
