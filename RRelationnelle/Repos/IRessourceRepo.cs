using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Repos
{
   public interface IRessourceRepo
    {
        public Task<List<Ressource>> GetFormation(JArray result);
        public Task<Ressource> GetRessourceById(string id);
        public Task<ActionResult<bool>> Delete();
        
    }
}
