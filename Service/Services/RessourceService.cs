
using Business.Interfaces;
using Commun.dto;
using Commun.Responses;
using DataAccess.Interfaces;
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
    public class RessourceService : IRessourceService
    {
       /* private readonly IRessourceRepo _repo;*/
        private readonly IApiGouv _api;
        private readonly IRessourceRepo _repo;
        private readonly ICategoryRepository _categRepo;
        private readonly IUserRepo _user;
        public RessourceService( IApiGouv api,IRessourceRepo rep,ICategoryRepository categRepo, IUserRepo user)
        {
            _api = api;
            _repo = rep;
            _categRepo = categRepo;
            _user = user;
        }

        public Task<Response<bool>> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<RessourceDto>> Create(RessourceDto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Response<RessourceDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<AlternanceDto>>> GetFormation(string rome, string romeDomain, string caller,string departement)
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
                        Category = await _categRepo.Create(new Category("Formation",true,1));
                    }

                  /*  var mapcateg = MappingCategory.MappingCategoryL();
                    var CategDto = mapcateg.Map<Category, CategoryDto>(Category);*/

                    if (Ressource== null)
                    {
                        var user =await  _user.Get(2);
                        var ressourcedto = new RessourceDto(name, 0, id,onisepUrl,1);
                        var map = MappingRessource.MappingRessourcesDtoToModel(Category,user);
                        var ressourceModel  = map.Map<RessourceDto, Ressource>(ressourcedto);
                        await _repo.Create(ressourceModel);
                    }
                    else if(Ressource._title != name)
                    {
                        Ressource._title = name;
                        await _repo.Update(Ressource, Ressource.ID_Ressource);
                    }
                    if (name != null && id != null)
                    {
                         var alternance = new AlternanceDto(name, Category.Id_Category, id, onisepUrl, 1, Diploma, period, capacity, ville, zipcode, emailcontact, departement);
                         list.Add(alternance);
                    }
                }
                if (list != null)
                {
                    return new Response<List<AlternanceDto>>(200, list, "Données trouvées");
                }
                else if (list == null)
                {
                    return new Response<List<AlternanceDto>>(404, null, "Not found");

                }
                else
                {
                    return new Response<List<AlternanceDto>>(500, null, "Another statut code");

                }
            }

            return new Response<List<AlternanceDto>>(404, null, "Not found");
        }

        public Task<Response<RessourceDto>> Update(RessourceDto obj, int id)
        {
            throw new NotImplementedException();
        }


       

        public async Task<Response<bool>> AddView(int id)
        {
            if (await _repo.AddView(id) != 0)
            {
                return new Response<bool>(200, true, "Vue ajoutée");
            }
            else
            {
                return new Response<bool>(200, false, "Echec ajout de vue");
            }
        }

        public async Task<Response<List<JobDto>>> GetJob(string secteurActivite, string departement)
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
                        Category = await _categRepo.Create(new Category("Job", true, 2));
                    }
                    /*var mapcateg = MappingCategory.MappingCategoryL();
                    var CategDto = mapcateg.Map<Category, CategoryDto>(Category);*/

                    if (Ressource == null)
                    {
                        var user = await _user.Get(2);
                        var ressourcedto = new RessourceDto(name, 0, id, url, 2);
                        var map = MappingRessource.MappingRessourcesDtoToModel(Category,user);
                        var ressourceModel = map.Map<RessourceDto, Ressource>(ressourcedto);
                        await _repo.Create(ressourceModel);
                    }
                    else if (Ressource._title != name)
                    {
                        Ressource._title = name;
                        await _repo.Update(Ressource, Ressource.ID_Ressource);
                    }
                    if (name != null && id != null)
                    {
                        var Job = new JobDto(name, Category.Id_Category, id, url, 1, description, experienceLibelle, ville, salaire, zipcode, typeContrat);
                        list.Add(Job);   
                    }
                }
                if (list != null)
                {
                    return new Response<List<JobDto>>(200, list, "Données trouvées");
                }
                else if (list == null)
                {
                    return new Response<List<JobDto>>(404, null, "Not found");

                }
                else
                {
                    return new Response<List<JobDto>>(500, null, "Another statut code");

                }
            }

            return new Response<List<JobDto>>(404, null, "Not found");
        }

        public async Task<Response<UserfavoriteRessourceDto>> AddFavorite(int user,int ressource)
        {
            try
            {
                var userM = await _user.Get(user);
                if (userM!=null)
                {
                    var RessourceM = await _repo.Get(ressource);
                    if (RessourceM != null)
                    {
                        
                        var Model = await _repo.CheckUserFavoriteByObject(userM,RessourceM);
                        if (Model==null)
                        {
                            var modelFav = new UserFavorite(RessourceM, userM);
                            var response = _repo.AddUserFavorite(modelFav);
                            if (response != null)
                            {
                                return new Response<UserfavoriteRessourceDto>(200, null, "Ressource ajoutée en favorite");

                            }
                            else
                            {
                                 return new Response<UserfavoriteRessourceDto>(404, null, "Echec ajout favoris");

                            }
                        }else
                        {
                            return new Response<UserfavoriteRessourceDto>(404, null, "Vous avez déjà cette ressource en favorite");

                        }
                    }
                    else
                    {
                        return new Response<UserfavoriteRessourceDto>(404, null, "Ressource inexistante");
                    }
                }
                else
                {
                    return new Response<UserfavoriteRessourceDto>(404, null, "User inexistant");
                }
            }
            catch(Exception ex)
            {
                return new Response<UserfavoriteRessourceDto>(500, null, ex.Message);
            }
        }
    }
}
