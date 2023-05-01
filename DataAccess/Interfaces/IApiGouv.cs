using Newtonsoft.Json.Linq;
using RRelationnelle.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IApiGouv
    {
        public Task<JArray> GetFormation();
        public Task<JArray> GetJob();
    }
}
