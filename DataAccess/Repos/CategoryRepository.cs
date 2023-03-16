using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public class CategoryRepository : IRepository<Categorie>
    {
        //private Categorie _entities;
        private readonly RrelationnelApiContext _ctx;

        public CategoryRepository(RrelationnelApiContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Archive(int id)
        {
            var entity = await _ctx.Category.FindAsync(id);
            entity.isActive = false;
            _ctx.Category.Update(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<Categorie> Get(int id)
        {
            try
            {
                var categorie = await _ctx.Category.FindAsync(id);
                return categorie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Categorie> Create(Categorie category)
        {
            try
            {
                _ctx.Category.Add(category);
               await _ctx.SaveChangesAsync();
                return category;
            }
            catch
            {
                return null;
            }
        }

        //public IEnumerable<Categorie> ListCategory()
       // {
                
        //}

      public async Task<ActionResult<IEnumerable<Categorie>>> ListCategory()
        {
             List<Categorie> categorie = new List<Categorie>();
            categorie = await _ctx.Category.ToListAsync();
            return categorie;
        }

       

        public async Task<IEnumerable<Categorie>> ListCategory2()
        {
            List<Categorie> categorie = new List<Categorie>();
            categorie = await _ctx.Category.ToListAsync();
            return categorie;
        }

        public async Task<Categorie> Update(Categorie category,int id)
        {
           var entity = await _ctx.Category.FindAsync(id);
            entity.idcreator = category.idcreator;
            entity._name = category._name;
            _ctx.Category.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
    }

}
