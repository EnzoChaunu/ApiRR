
using Business.Interfaces;
using Commun.dto;
using DataAccess.Interfaces;
using Newtonsoft.Json.Linq;
using RRelationnelle.dto;
using RRelationnelle.Mapping;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public class RessourceService : IRessourceService
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
                    var Category = await _categRepo.GetByName("Formation");
                    if (Category == null)
                    {
                        Category = await _categRepo.Create(new Category("Formation",true,2));
                    }
                    var mapcateg = MappingCategory.MappingCategoryL();
                    var CategDto = mapcateg.Map<Category, CategoryDto>(Category);
                    if (Ressource== null)
                    {  
                        var ressourcedto = new RessourceDto(name, 2,id,onisepUrl,CategDto.Id_Category);
                        var map = MappingRessource.MappingRessources();
                        var ressourceModel  = map.Map<RessourceDto, Ressource>(ressourcedto);
                        await _repo.Create(ressourceModel);
                    }
                    else if(Ressource._title != name)
                    {
                        Ressource._title = name;
                        await _repo.Update(Ressource, Ressource.ID_Ressource);
                    }
                    var alternance = new AlternanceDto(name,CategDto.Id_Category,id, onisepUrl, 1, Diploma, period, capacity, ville, zipcode, emailcontact, departement);
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


       

        public async Task<bool> AddView(int id)
        {
            if (await _repo.AddView(id) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<JobDto>> GetJob(string secteurActivite, string departement)
        {
            List<JobDto> list = new List<JobDto>();
            var response = await _api.GetJob(secteurActivite, departement);
            if (response != null)
            {
                foreach (JObject obj in response)
                {
                    // je recupere les info dont j'ai besoins dans mon tableau de resultats renvoyé par l'api
                    string id = (string)obj["id"];
                    string name = (string)obj["intitule"];
                    string description = (string)obj["description"];
                    string typeContrat = (string)obj["typeContrat"];
                    string experienceLibelle = (string)obj["experienceLibelle"];
                    string salaire = (string)obj["salaire"]["libelle"];
                    string url = null;
                    if ((string)obj["origineOffre"]["urlOrigine"] != null)
                    {
                        url = (string)obj["origineOffre"]["urlOrigine"];
                    }
                    string ville = (string)obj["lieuTravail"]["libelle"];
                    string zipcode = (string)obj["lieuTravail"]["commune"];
                    var Ressource = await _repo.Get(id);

                    var Category = await _categRepo.GetByName("Job");
                    if (Category == null)
                    {
                        Category = await _categRepo.Create(new Category("Job", true, 1));
                    }
                    var mapcateg = MappingCategory.MappingCategoryL();
                    var CategDto = mapcateg.Map<Category, CategoryDto>(Category);

                    if (Ressource == null)
                    {
                        var ressourcedto = new RessourceDto(name, 1, id, url, CategDto.Id_Category);
                        var map = MappingRessource.MappingRessources();
                        var ressourceModel = map.Map<RessourceDto, Ressource>(ressourcedto);
                        await _repo.Create(ressourceModel);
                    }
                    else if (Ressource._title != name)
                    {
                        Ressource._title = name;
                        await _repo.Update(Ressource, Ressource.ID_Ressource);
                    }
                    var Job = new JobDto(name, CategDto.Id_Category, id, url, 1, description, experienceLibelle, ville, salaire, zipcode, typeContrat);
                    list.Add(Job);
                }
                return list;
            }

            return null;
        }
    }
}
