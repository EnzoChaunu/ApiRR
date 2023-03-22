using AutoMapper;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RRelationnelle.dto;
using RRelationnelle.Mapping;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public class RessourceService : IService<RessourceDto>
    {
       /* private readonly IRessourceRepo _repo;*/
        private readonly IApiGouv _api;
        private readonly IRessourceRepo _repo;
        public RessourceService( IApiGouv api,IRessourceRepo rep)
        {
            _api = api;
            _repo = rep;
        }

        public Task<bool> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RessourceDto> Create(RessourceDto obj)
        {
            throw new NotImplementedException();
        }

        public Task<RessourceDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AlternanceDto>> GetFormation(string rome, string romeDomain, string caller)
        {
            List<AlternanceDto> list= new List<AlternanceDto>();
            var response = await  _api.GetFormation(caller,rome,romeDomain);
            if (response != null)
            {
                foreach (JObject obj in response)
                {
                    // je recupere les info dont j'ai besoins dans mon tableau de resultats renvoyé par l'api
                    string id = (string)obj["id"];
                    string name = (string)obj["longTitle"];
                    string onisepUrl = (string)obj["onisepUrl"];
                    string Diploma = (string)obj["diploma"];
                    string period = (string)obj["onisepUrl"];
                    string capacity = (string)obj["capacity"];
                    string ville = (string)obj.SelectToken("place.city");
                    string zipcode = (string)obj.SelectToken("place.zipCode");
                    string emailcontact = (string)obj.SelectToken("contact.email");

                    if (_repo.Get(id) == null)
                    {
                        var ressourcedto = new RessourceDto(name, 1,id,onisepUrl,1);
                        var map = MappingRessource.MappingRessources();
                        var ressourceModel  = map.Map<RessourceDto, Ressource>(ressourcedto);
                        await _repo.Create(ressourceModel);
                    }
                    var alternance = new AlternanceDto(name,1,id, onisepUrl, 1, Diploma, period, capacity, ville, zipcode, emailcontact);
                    list.Add(alternance);
                }
                /* var reponse = await _repo.GetFormation(response);
                 var mapper = MappingRessource.MappingAlternance();
                 List<AlternanceDto> Ressourcedto = new List<AlternanceDto>();
                Ressourcedto = mapper.Map<List<Alternances>, List<AlternanceDto>>(response);
                 return Ressourcedto;*/
                return list;
            }
           
            return null; 
        }

        public Task<RessourceDto> Update(RessourceDto obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
