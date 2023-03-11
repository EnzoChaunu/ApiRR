using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RRelationnelle.Repos
{
    public class RessourcesRepo : IRessourceRepo
    {
        private readonly RrelationnelApiContext _Dbcontext;
        private readonly ICategoryRepository _categ;
        private readonly IUserRepo _user;
      
        public RessourcesRepo(RrelationnelApiContext ctx, ICategoryRepository categ, IUserRepo user)
        {
            _Dbcontext = ctx;
            _categ = categ;
            _user = user;
        }


        public Task<ActionResult<bool>> Delete()
        {
            throw new NotImplementedException();
        }

        


        public async Task<Ressource> GetRessourceById(string id)
        {
            Ressource ressource = await _Dbcontext.Ressource.FindAsync(id);
            return ressource;
        }

        public async Task<List<Ressource>> GetFormation(JArray result)
        {
            using var transaction = await _Dbcontext.Database.BeginTransactionAsync();
            
                
                foreach (JObject obj in result)
                {

                    string id = (string)obj["id"];
                    string name = (string)obj["title"];
                    string onisepUrl = (string)obj["onisepUrl"];
                    var categ = await _categ.GetByid(1);
                    var user = await _user.GetUserById(1);
                var ressource = new Ressource
                {
                    _reference = id,
                    _title = name,
                    category = categ,
                    _url = onisepUrl,
                    modification = user
                    };
                    _Dbcontext.Ressource.Add(ressource);
                    int nb =  _Dbcontext.SaveChanges();
               
            }
                    await transaction.CommitAsync();

            
            return await _Dbcontext.Ressource.ToListAsync();
        }
    }
}
