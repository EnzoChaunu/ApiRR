using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public class CategoryRepository : ICategoryRepository
    {
        //private Categorie _entities;
        private readonly RrelationnelApiContext _ctx;

        public CategoryRepository(RrelationnelApiContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Archive(int id)
        {
            try
            {
                var entity = await _ctx.Category.FindAsync(id);
                entity.isActive = false;
                _ctx.Category.Update(entity);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<Category> Get(dynamic id)
        {
            try
            {
                var categorie = await _ctx.Category.FindAsync(id);
                return categorie;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<Category> Create(Category category)
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

        public async Task<IEnumerable<Category>> ListCategory()
        {
            try
            {
                List<Category> categorie = new List<Category>();
                categorie = await _ctx.Category.ToListAsync();
                return categorie;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<Category> Update(Category category,int id)
        {
            try
            {
                var entity = await _ctx.Category.FindAsync(id);
                entity.idcreator = category.idcreator;
                entity._name = category._name;
                _ctx.Category.Update(entity);
                await _ctx.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public  async Task<Category> GetByName(string name)
        {
            try
            {
                var categ = await _ctx.Category.FirstOrDefaultAsync(p => p._name == name);
                return categ;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
    }

}
