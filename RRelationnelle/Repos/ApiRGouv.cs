using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RRelationnelle.Repos
{
    public class ApiRGouv : IApiGouv
    {
        private readonly IRessourceRepo _repo;
         
        public ApiRGouv(IRessourceRepo repo)
        {
            _repo = repo;
        }
        public async Task<List<Ressource>> GetFormation(string caller, string rome, string romesDomain)
        {


            using var client = new HttpClient();

            var uriBuilder = new UriBuilder("https://labonnealternance.apprentissage.beta.gouv.fr/api/V1/formations");
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["romeDomain"] = romesDomain;
            query["romes"] = rome;
            query["caller"] = caller;
            uriBuilder.Query = query.ToString();
            var response = await client.GetAsync(uriBuilder.Uri);
            var content = await response.Content.ReadAsStringAsync();

            // Rétablir la connexion et ouvrir le contexte

            if (!string.IsNullOrEmpty(content))
            {
                client.Dispose();
                JObject topLevel = JObject.Parse(content);
                JArray result = (JArray)topLevel.SelectToken("results");
                var reponse = await _repo.GetFormation(result);
                return reponse;
            }
            else
            {
                return null;
            }

        }

    }
}
