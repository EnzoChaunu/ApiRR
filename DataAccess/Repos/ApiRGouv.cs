﻿using DataAccess.Interfaces;
using Newtonsoft.Json.Linq;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
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
        public async Task<JArray> GetFormation(string caller, string rome, string romesDomain)
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
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
