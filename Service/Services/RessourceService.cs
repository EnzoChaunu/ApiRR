
using Business.Interfaces;
using Commun.dto;
using Commun.Responses;
using DataAccess.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using RRelationnelle.dto;
using RRelationnelle.Mapping;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Mail;
using System.Net;
using Commun.Hash;
using System.Reflection.Metadata.Ecma335;

namespace RRelationnelle.Service
{
    public class RessourceService : IRessourceService
    {
        /* private readonly IRessourceRepo _repo;*/
        private readonly IApiGouv _api;
        private readonly IRessourceRepo _repo;
        private readonly ICategoryRepository _categRepo;
        private readonly IUserRepo _user;
        private readonly IMemoryCache _cache;
        private Dictionary<string, Dictionary<string, List<AlternanceDto>>> _alternancesByDomainAndDept;
        private Dictionary<string, List<JobDto>> _JobByDomainAndDept;


        public RessourceService(IApiGouv api, IRessourceRepo rep, ICategoryRepository categRepo, IUserRepo user, IMemoryCache optionsAccessor)
        {
            _api = api;
            _repo = rep;
            _categRepo = categRepo;
            _user = user;
            _cache = optionsAccessor;
            _alternancesByDomainAndDept = new Dictionary<string, Dictionary<string, List<AlternanceDto>>>();
            _JobByDomainAndDept = new Dictionary<string, List<JobDto>>();


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

        public async Task GetFormation()
        {
            List<AlternanceDto> liste = new List<AlternanceDto>();
            var user = await _user.GetByEmail("chaunu.enzo@gmail.com");
            int idress = 0;
            if (user != null)
            {
                var response = await _api.GetFormation();
                var Category = await _categRepo.GetByName("Formation");

                if (Category == null)
                {
                    Category = await _categRepo.Create(new Category("Formation", true, user));
                }
                foreach (var result in response)
                {
                    JArray resultArray = (JArray)result;
                    foreach (JObject obj in result)
                    {
                        // je recupere les info dont j'ai besoins dans mon tableau de resultats renvoyé par l'api
                        string id = (string)obj["id"];
                        string name = (string)obj["longTitle"];
                        string onisepUrl = (string)obj["onisepUrl"];
                        string Diploma = (string)obj["diploma"];
                        string period = (string)obj["period"];
                        string capacity = (string)obj["capacity"];
                        string emailcontact = null;
                        string rome = (string)obj["romes"][0]["code"];
                        string entreprise = (string)obj["company"]["name"];
                        string Domain = rome.Substring(0, 1);
                        if ((string)obj["contact"] != null)
                        {
                            emailcontact = (string)obj["contact"]["email"];
                        }
                        string ville = (string)obj["place"]["city"];
                        string departement = (string)obj["place"]["departementNumber"];
                        string zipcode = (string)obj["place"]["zipCode"];


                        var Ressource = await _repo.Get(id);

                        /*  var mapcateg = MappingCategory.MappingCategoryL();
                          var CategDto = mapcateg.Map<Category, CategoryDto>(Category);*/

                        if (Ressource == null)
                        {

                            var ressourcedto = new RessourceDto(name, 0, id, onisepUrl, user.Id_User,0);
                            var map = MappingRessource.MappingRessourcesDtoToModel(Category, user);
                            var ressourceModel = map.Map<RessourceDto, Ressource>(ressourcedto);
                            var ressource = await _repo.Create(ressourceModel);
                            idress = ressource.ID_Ressource;
                        }
                        else if (Ressource._title != name)
                        {
                            Ressource._title = name;
                            await _repo.Update(Ressource, Ressource.ID_Ressource);
                            idress = Ressource.ID_Ressource;
                        }
                        else
                        {
                            idress = Ressource.ID_Ressource;
                        }
                        if (name != null && id != null)
                        {
                            var alternance = new AlternanceDto(name, Category.Id_Category, id, onisepUrl, user.Id_User, idress, Diploma, period, capacity, ville, zipcode, emailcontact, departement, Domain, entreprise);
                            if (!_alternancesByDomainAndDept.ContainsKey(Domain))
                            {
                                // Si elle n'existe pas, la créer
                                _alternancesByDomainAndDept[Domain] = new Dictionary<string, List<AlternanceDto>>();
                            }

                            // Vérifier si la sous-catégorie du département existe dans le dictionnaire
                            if (!_alternancesByDomainAndDept[Domain].ContainsKey(departement))
                            {
                                // Si elle n'existe pas, la créer
                                _alternancesByDomainAndDept[Domain][departement] = new List<AlternanceDto>();
                            }

                            // Ajouter l'objet Alternance à la sous-catégorie correspondante
                            _alternancesByDomainAndDept[Domain][departement].Add(alternance);
                            Console.WriteLine("ressource add");


                        }
                    }
                }
                _cache.Set("Alternance", _alternancesByDomainAndDept);
                Console.WriteLine("All alternances added");


            }



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

        public async Task GetJob()
        {
            List<JobDto> list = new List<JobDto>();
            var user = await _user.GetByEmail("chaunu.enzo@gmail.com");
            int idress = 0;
            if (user != null)
            {
                var response = await _api.GetJob();
                var Category = await _categRepo.GetByName("Job");
                if (Category == null)
                {
                    Category = await _categRepo.Create(new Category("Job", true, user));
                }
                if (response != null)
                {
                    foreach (var result in response)
                    {
                        foreach (JObject obj in result)
                        {
                            // je recupere les info dont j'ai besoins dans mon tableau de resultats renvoyé par l'api
                            string id = (string)obj["id"];
                            string name = (string)obj["intitule"];
                            string description = (string)obj["description"];
                            string typeContrat = (string)obj["typeContrat"];
                            string CodeNaf = (string)obj["secteurActivite"];
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


                            /*var mapcateg = MappingCategory.MappingCategoryL();
                            var CategDto = mapcateg.Map<Category, CategoryDto>(Category);*/

                            if (Ressource == null)
                            {

                                var ressourcedto = new RessourceDto(name, 0, id, url, user.Id_User,0);
                                var map = MappingRessource.MappingRessourcesDtoToModel(Category, user);
                                var ressourceModel = map.Map<RessourceDto, Ressource>(ressourcedto);
                               var ressource =  await _repo.Create(ressourceModel);
                                idress = ressource.ID_Ressource;
                            }
                            else if (Ressource._title != name)
                            {
                                Ressource._title = name;
                                await _repo.Update(Ressource, Ressource.ID_Ressource);
                                idress = Ressource.ID_Ressource;
                            }
                            else
                            {
                                idress = Ressource.ID_Ressource;
                            }
                            if (name != null && id != null)
                            {
                                var Job = new JobDto(name, Category.Id_Category, id, url, user.Id_User,idress, description, experienceLibelle, ville, salaire, zipcode, typeContrat, CodeNaf);



                                if (!_JobByDomainAndDept.ContainsKey(CodeNaf))
                                {
                                    // Si elle n'existe pas, la créer
                                    _JobByDomainAndDept[CodeNaf] = new List<JobDto>();
                                }


                                // Ajouter le job à la liste correspondante
                                _JobByDomainAndDept[CodeNaf].Add(Job);
                                Console.WriteLine("Job add");

                            }
                        }
                    }
                    _cache.Set("Job", _JobByDomainAndDept);
                    Console.WriteLine("All jobs added");

                }
            }



        }

        public async Task<Response<UserfavoriteRessourceDto>> AddFavorite(string token, int ressource)
        {
            try
            {
                var HashToken = Hashing.HashToken(token);
                var userM = await _user.GetUserByToken(HashToken);
                if (userM != null)
                {
                    var RessourceM = await _repo.Get(ressource);
                    if (RessourceM != null)
                    {

                        var Model = await _repo.CheckUserFavoriteByObject(userM, RessourceM);
                        if (Model == null)
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
                        }
                        else
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
                    return new Response<UserfavoriteRessourceDto>(401, null, "Unauthorize");
                }
            }
            catch (Exception ex)
            {
                return new Response<UserfavoriteRessourceDto>(500, null, ex.Message);
            }
        }

        public void RefreshCache()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<AlternanceDto>>> GetFormationForFront(string romeDomain, string departement)
        {
            List<AlternanceDto> liste = new List<AlternanceDto>();

            // var domainDict = _alternancesByDomainAndDept;

            var domainDict = await _cache.GetOrCreateAsync("Alternance", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                return Task.FromResult(_alternancesByDomainAndDept);
            });

            if (domainDict != null && domainDict.TryGetValue(romeDomain, out var deptDict))
            {
                if (deptDict.TryGetValue(departement, out var alternances))
                {
                    liste = alternances.ToList();
                }
            }

            if (liste != null)
            {
                return new Response<List<AlternanceDto>>(200, liste, "Données trouvées");
            }
            else
            {
                return new Response<List<AlternanceDto>>(404, null, "Not found");

            }

        }

        public async Task<Response<List<JobDto>>> GetJobForFront(string secteurActivite)
        {
            List<JobDto> list = new List<JobDto>();

            var domainDict = await _cache.GetOrCreateAsync("Job", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                return Task.FromResult(_JobByDomainAndDept);
            });

            if (domainDict != null && domainDict.TryGetValue(secteurActivite, out var Job))
            {
                list = Job.ToList();
            }

            if (list != null)
            {
                return new Response<List<JobDto>>(200, list, "Données trouvées");
            }
            else if (list == null)
            {
                return new Response<List<JobDto>>(200, list, "Not found");

            }
            else
            {
                return new Response<List<JobDto>>(500, null, "Another statut code");

            }
        }

        public async Task<Response<List<RessourceDto>>> GetListRessourceByUser(string token)
        {
            var ressourceListDto = new List<RessourceDto>();
            var HashToken = Hashing.HashToken(token);
            var user = await _user.GetUserByToken(HashToken);
            if (user != null)
            {
                List<Ressource> ressources = await _repo.GetRessourceListUser(user.Id_User);
                var map = MappingRessource.MappingRessourcesModelToDto();
                if (ressources.Count > 1)
                {
                    ressourceListDto = map.Map<List<Ressource>, List<RessourceDto>>(ressources);
                    if (ressourceListDto != null)
                    {

                        return new Response<List<RessourceDto>>(200, ressourceListDto, "Données trouvées");
                    }
                    else
                    {

                        return new Response<List<RessourceDto>>(200, ressourceListDto, "pas de données");
                    }

                }
                else
                {

                    var ressourceDto = map.Map<Ressource, RessourceDto>(ressources.FirstOrDefault());
                    if (ressourceDto != null)
                    {
                        ressourceListDto.Add(ressourceDto);
                        return new Response<List<RessourceDto>>(200, ressourceListDto, "Données trouvées");
                    }
                    else
                    {

                        return new Response<List<RessourceDto>>(200, ressourceListDto, "pas de favoris");
                    }

                }

            }
            else
            {
                return new Response<List<RessourceDto>>(401, null, "Unauthorize");
            }
        }

        public async Task<Response<bool>> ShareRessource(int ress, string expediteur, string destinataireEmail)
        {
            var token = Hashing.HashToken(expediteur);
            var expe = await _user.GetUserByToken(token);
            if (expe != null)
            {
                if (destinataireEmail != null)
                {
                    var ressource = await _repo.Get(ress);
                    if (ressource != null)
                    {
                        // Extraction du domaine de l'adresse e-mail
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);


                        // Configuration du client SMTP pour Gmail

                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(expe.Email, "sicqjbexttqxcffa");
                        smtp.EnableSsl = true;

                        // Envoi du message e-mail
                        try
                        {
                            MailMessage mail = new MailMessage();
                            mail.From = new MailAddress("chaunu.enzo@gmail.com");
                            mail.To.Add(destinataireEmail);
                            mail.Subject = "Partage de ressource de la part de " + expe.LName;
                            mail.Body = "Hey je t'ai partagé une ressource j'espère qu'elle va t'interésser !\n\n" + ressource._title + "\n\n" + ressource._url + "\n\n\n\nCeci est un message autogénéré envoyé depuis l'application Rrelationnel de la part de " + expe.FName + " " + expe.LName;
                            smtp.Send(mail);
                            var reponse = await _repo.ShareRessource(ress);
                            return new Response<bool>(200, true, "Email envoyé avec succès");
                        }

                        // Détection du fournisseur de messagerie

                        catch (SmtpException ex)
                        {

                            return new Response<bool>(500, false, ex.Message);
                        }

                    }
                    else
                    {

                        return new Response<bool>(404, false, "Ressource non trouvéee");
                    }
                }
                else
                {
                    return new Response<bool>(404, false, "Mail du destinataire non renseigné");
                }
            }
            else
            {
                return new Response<bool>(401, false, "Non-autorisé");
            }
        }

        public async Task<Response<dynamic>> GetRessource(int id)
        {
            if (id != 0)
            {
                var ressource = await _repo.Get(id);
                if (ressource != null)
                {
                    switch(ressource.category.Id_Category)
                    {
                        case 1:
                            var alter = await _cache.GetOrCreateAsync("Alternance", entry =>
                            {
                                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                                return Task.FromResult(_alternancesByDomainAndDept);
                            });
                            var alternance = alter.Values
                                .SelectMany(domaine => domaine.Values.SelectMany(departement => departement))
                                .FirstOrDefault(alternance => alternance._id == id);

                            if (alternance!=null)
                            {
                                var Bddress = await _repo.Get(alternance._id);
                                alternance._views = Bddress._views;
                                alternance.shared = Bddress._shared;
                                return new Response<dynamic>(200, alternance, "Alternance trouvée");

                            }
                            else
                            {
                                return new Response<dynamic>(404, null, "Cette alternance n'existe pas");

                            }


                        case 2:
                            var job = await _cache.GetOrCreateAsync("Job", entry =>
                            {
                                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                                return Task.FromResult(_JobByDomainAndDept);
                            });

                            var travail = job.Values
                                    .SelectMany(CodeNaf => CodeNaf)
                                    .FirstOrDefault(taff => taff._id == id);

                            if (travail!=null)
                            {
                                var Bddress = await _repo.Get(travail._id);
                                travail._views = Bddress._views;
                                travail.shared = Bddress._shared;
                                return new Response<dynamic>(200, travail, "Job trouvé");
                                
                            }
                            else
                            {
                                return new Response<dynamic>(404, null, "Ce Job n'existe pas");
                               
                            }
                            

                        default: return new Response<dynamic>(404, null, "Cette ressource n'existe pas");
                    }
                }
                else
                {
                    return new Response<dynamic>(404, null, "Cette ressource n'existe pas");
                }
            }
            else
            {
                return new Response<dynamic>(404, null, "reference nulle");
            }
        }

        public async Task<Response<bool>> DeleteFavorite(string token, int ressource)
        {
            var hash = Hashing.HashToken(token);
            var expe = await _user.GetUserByToken(hash);
            if(expe != null)
            {
                var delete = await _repo.DeleteFavorite(ressource,expe.Id_User);
                if(delete == 1 )
                {
                    return new Response<bool>(200, true, "Favoris supprimé");
                }
                else
                {
                    return new Response<bool>(404, false, "Echec suppression");
                }
            }
            else
            {
                return new Response<bool>(401, false, "User introuvable");
            }
        }
    }
}
