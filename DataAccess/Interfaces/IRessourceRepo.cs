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
        public Task<ActionResult<bool>> Delete();
        public Task<int> AddView(int id);

    }
}
