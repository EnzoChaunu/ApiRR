using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RRelationnelle.dto;
using RRelationnelle.Mapping;
using RRelationnelle.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public class RessourceService : IRessourceService
    {
       /* private readonly IRessourceRepo _repo;*/
        private readonly IApiGouv _api;
        public RessourceService( IApiGouv api)
        {
           
            _api = api;
        }

        public Task<ActionResult<RessourceDto>> Create()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<bool>> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RessourceDto>> GetFormation(string rome, string romeDomain, string caller)
        {
            List<AlternanceDto> list= new List<AlternanceDto>();
            var response = await  _api.GetFormation(caller,rome,romeDomain);
            if (response != null)
            {
                var mapper = MappingRessource.MappingRessources();
                List<RessourceDto> Ressourcedto = new List<RessourceDto>();
               Ressourcedto = mapper.Map<List<Ressource>, List<RessourceDto>>(response);
                return Ressourcedto;
            }
           
            return null; 
        }
    }
}
