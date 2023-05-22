using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public CategoryRepository(RrelationnelApiContext ctx,IConfiguration config)
        {
            _ctx = ctx;
            _configuration = config;
        }

        private RrelationnelApiContext CreateDbContext()
        {
            var connectionString = _configuration.GetConnectionString("ApiRessourceConnection");
            var optionsBuilder = new DbContextOptionsBuilder<RrelationnelApiContext>()
                .UseSqlServer(connectionString);

            return new RrelationnelApiContext(optionsBuilder.Options);
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
                var context = CreateDbContext();
                context.Entry(category.Creator).State = EntityState.Unchanged;
                context.Category.Add(category);
               await context.SaveChangesAsync();
                return category;
            }
            catch
            {
                return null;
            }
        }
       
        public async Task<List<Category>> ListCategory()
        {
            try
            {
                List<Category> categorie = new List<Category>();
                categorie = await _ctx.Category.ToListAsync();
                return categorie.ToList();
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
                entity.Creator = category.Creator;
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
            var context = CreateDbContext();
            try
            {
                var categ = await context.Category.FirstOrDefaultAsync(p => p._name == name);
                return categ;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
    }

}
