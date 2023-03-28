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
        public Task<List<Alternances>> GetFormation(JArray result);
        public Task<Ressource> GetRessourceById(string id);
        public Task<ActionResult<bool>> Delete();

    }
}
