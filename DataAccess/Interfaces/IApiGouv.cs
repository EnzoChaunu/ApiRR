using RRelationnelle.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IApiGouv
    {
        public Task<List<Alternances>> GetFormation(string caller, string rome, string romesDomain);
    }
}
