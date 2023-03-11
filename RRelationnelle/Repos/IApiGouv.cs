using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Repos
{
    public interface IApiGouv
    {
        public Task<List<Ressource>> GetFormation(string caller, string rome, string romesDomain);
    }
}
