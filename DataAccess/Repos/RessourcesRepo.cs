using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
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
            try
            {
                Ressource ressource = await _Dbcontext.Ressource.FindAsync(id);
                return ressource;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<List<Alternances>> GetFormation(JArray result)
        {
            //using var transaction = await _Dbcontext.Database.BeginTransactionAsync();
            //await transaction.CommitAsync();
            return null;
        }

        public async Task<Ressource> Create(Ressource obj)
        {
            try
            {
                await _Dbcontext.Ressource.AddAsync(obj);
                _Dbcontext.SaveChanges();
                return await Get(obj._reference);
            }
            catch (DbUpdateException)
            {
                return null;
            }


        }

        public async Task<Ressource> Update(Ressource obj, int id)
        {
            try
            {
                var entity = await _Dbcontext.Ressource.FindAsync(id);
                entity._title = obj._title;
                _Dbcontext.Ressource.Update(entity);
                await _Dbcontext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public Task<bool> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ressource> Get(dynamic id)
        {
            try
            {
                string _id = id;
                var ressource = await _Dbcontext.Ressource.FirstOrDefaultAsync(p => p._reference == _id);
                return ressource;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<int> AddView(int id)
        {
            try
            {
                var entity = await _Dbcontext.Ressource.FindAsync(id);
                entity._views++;
                _Dbcontext.Ressource.Update(entity);
                return await _Dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return 0;
            }
        }
    }
}
