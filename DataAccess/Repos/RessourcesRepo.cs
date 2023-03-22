using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RRelationnelle.Repos
{
    public class RessourcesRepo : IRessourceRepo
    {
        private readonly RrelationnelApiContext _Dbcontext;
        private readonly CategoryRepository _categ;
        private readonly IUserRepo _user;

        public RessourcesRepo(RrelationnelApiContext ctx, CategoryRepository categ, IUserRepo user)
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

        public async Task<List<Alternances>> GetFormation(JArray result)
        {
            //using var transaction = await _Dbcontext.Database.BeginTransactionAsync();
            //await transaction.CommitAsync();
            return null;
        }

        public async Task<Ressource> Create(Ressource obj)
        {
            _Dbcontext.Ressource.Add(obj);
            _Dbcontext.SaveChanges();
            return await Get(obj._reference);
            
        }

        public Task<Ressource> Update(Ressource obj, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ressource> Get(dynamic id)
        {
            string _id = id; 
            Ressource ressource =  await  _Dbcontext.Ressource.FirstOrDefaultAsync(p => p._reference ==_id);
            return ressource;
        }
    }
}
