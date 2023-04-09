
using DataAccess.Interfaces;
using Newtonsoft.Json.Linq;
using RRelationnelle.dto;
using RRelationnelle.Mapping;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public class RessourceService : IService<RessourceDto>
    {
       /* private readonly IRessourceRepo _repo;*/
        private readonly IApiGouv _api;
        private readonly IRessourceRepo _repo;
        private readonly ICategoryRepository _categRepo;
        public RessourceService( IApiGouv api,IRessourceRepo rep,ICategoryRepository categRepo)
        {
            _api = api;
            _repo = rep;
            _categRepo = categRepo;
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

        public async Task<List<AlternanceDto>> GetFormation(string rome, string romeDomain, string caller,string departement)
        {
            List<AlternanceDto> list= new List<AlternanceDto>();
            var response = await  _api.GetFormation(caller,rome,romeDomain, departement);
            if (response != null)
            {
                foreach (JObject obj in response)
                {
                    // je recupere les info dont j'ai besoins dans mon tableau de resultats renvoyé par l'api
                    string id = (string)obj["id"];
                    string name = (string)obj["longTitle"];
                    string onisepUrl = (string)obj["onisepUrl"];
                    string Diploma = (string)obj["diploma"];
                    string period = (string)obj["period"];
                    string capacity = (string)obj["capacity"];
                    string emailcontact = null;
                    if ((string)obj["contact"] != null)
                    {
                         emailcontact = (string)obj["contact"]["email"];
                    }
                    string ville = (string)obj["place"]["city"];
                    string zipcode = (string)obj["place"]["zipCode"];
                    var Ressource = await _repo.Get(id);
                    if (Ressource== null)
                    {  
                        var Category = await _categRepo.GetByName("Formation");
                        var mapcateg = MappingCategory.MappingCategoryL();
                        var CategDto = mapcateg.Map<Category, CategoryDto>(Category);

                        var ressourcedto = new RessourceDto(name, 1,id,onisepUrl,CategDto.Id_Category);
                        var map = MappingRessource.MappingRessources();
                        var ressourceModel  = map.Map<RessourceDto, Ressource>(ressourcedto);
                        await _repo.Create(ressourceModel);
                    }
                    else if(Ressource._title != name)
                    {
                        Ressource._title = name;
                        await _repo.Update(Ressource, Ressource.ID_Ressource);
                    }
                    var alternance = new AlternanceDto(name,1,id, onisepUrl, 1, Diploma, period, capacity, ville, zipcode, emailcontact, departement);
                    list.Add(alternance);
                }
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
