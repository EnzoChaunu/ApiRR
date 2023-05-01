
using DataAccess.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;



namespace RRelationnelle.Repos
{
    public class ApiRGouv : IApiGouv
    {
        
         
        public ApiRGouv()
        {
           
        }
        public async Task<JArray> GetFormation()
        {
            JArray allresult = new JArray();
            string caller=  "chaunu.enzo@hotmail.fr";
            using var client = new HttpClient();
            string[] romesDomainList = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", };

            foreach(var rome in romesDomainList)
            {

                var uriBuilder = new UriBuilder("https://labonnealternance.apprentissage.beta.gouv.fr/api/V1/formations");
                var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
                query["romeDomain"] = rome;
           
            
                query["caller"] = caller;
                /*query["departement"] = departement;*/
                uriBuilder.Query = query.ToString();
                var response = await client.GetAsync(uriBuilder.Uri);
                var content = await response.Content.ReadAsStringAsync();

                // Rétablir la connexion et ouvrir le contexte

                if (!string.IsNullOrEmpty(content))
                {
                    JObject topLevel = JObject.Parse(content);
                    allresult.Add((JArray)topLevel.SelectToken("results"));
                
                }
            }
           client.Dispose();

            return allresult;
           

           
        }

        public async Task<JArray> GetJob()
        {
            // J'utilise mon token fournis par pole emploi pour acceder a mon compte et m'identifier en tant que user

            string url = "https://entreprise.pole-emploi.fr/connexion/oauth2/access_token?realm=%2Fpartenaire";

            var client = new HttpClient();

            var formContent = new FormUrlEncodedContent(new[]
            {
    new KeyValuePair<string, string>("grant_type", "client_credentials"),
    new KeyValuePair<string, string>("client_id", "PAR_rrelationnel_4808358137826570602408929692ca83d9da1dad2e728c782e0b5d679fa9460c"),
    new KeyValuePair<string, string>("client_secret", "f1fe21a91edd76e9d2340e97dc312e1102bfd8b3ea824ed3bcc90703bdeff964"),
    new KeyValuePair<string, string>("scope", "api_offresdemploiv2 o2dsoffre")
});
            // OAuth2 va ensuite vérifier ce token ainsi que mon client_id afin de me fournir un token qui servira a acceder au données des API
            var response = await client.PostAsync(url, formContent);
            string responseString = await response.Content.ReadAsStringAsync();

            // Extraction du token
            var tokenJson = JObject.Parse(responseString);
            string token = tokenJson["access_token"].ToString();

            var uriBuilder = new UriBuilder("https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/search");
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
          /*  query["secteurActivite"] = secteurActivite;
            query["departement"] = departement;*/
            uriBuilder.Query = query.ToString();
            var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();


            if (!string.IsNullOrEmpty(content))
            {
                client.Dispose();
                JObject topLevel = JObject.Parse(content);
                JArray result = (JArray)topLevel.SelectToken("resultats");
                return result;
            }
            else
            {
                return null;
            }

        }
    }
}
