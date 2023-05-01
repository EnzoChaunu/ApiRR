using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public RessourcesRepo(RrelationnelApiContext ctx, CategoryRepository categ, IUserRepo user, IConfiguration configuration)
        {
            _Dbcontext = ctx;
            _categ = categ;
            _user = user;
            _configuration = configuration;
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
            var context = CreateDbContext();
            try
            {
                context.Entry(obj.category).State = EntityState.Unchanged;
                context.Entry(obj.modification).State = EntityState.Unchanged;

                await context.Ressource.AddAsync(obj);
                context.SaveChanges();
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

        private RrelationnelApiContext CreateDbContext()
        {
            var connectionString = _configuration.GetConnectionString("ApiRessourceConnection");
            var optionsBuilder = new DbContextOptionsBuilder<RrelationnelApiContext>()
                .UseSqlServer(connectionString);

            return new RrelationnelApiContext(optionsBuilder.Options);
        }

        public async Task<Ressource> Get(dynamic id)
        {

            var context = CreateDbContext();
            switch (id.GetType().Name)
            {
                case "Int32":
                    try
                    {
                        int _id = id;
                        var ressource = await _Dbcontext.Ressource.Include(r => r.category).FirstOrDefaultAsync(r => r.ID_Ressource == _id);
                        return ressource;
                    }
                    catch (DbUpdateException)
                    {
                        return null;
                    }
                case "String":
                    try
                    {
                        string _id = id;
                        var ressource = await context.Ressource.FirstOrDefaultAsync(p => p._reference == _id);
                        return ressource;
                    }
                    catch (DbUpdateException)
                    {
                        return null;
                    }
                default:
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

        public async Task<UserFavorite> CheckUserFavoriteByObject(User user, Ressource ressource)
        {
            try
            {
                var userId = user.Id_User;
                var ressourceId = ressource.ID_Ressource;
                var UserFav = await _Dbcontext.UserFavorite.FirstOrDefaultAsync(p => p.user == user && p.ressource == ressource);
                return UserFav;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<UserFavorite> AddUserFavorite(UserFavorite fav)
        {
            try
            {
                _Dbcontext.Entry(fav.user).State = EntityState.Unchanged;

                await _Dbcontext.UserFavorite.AddAsync(fav);
                _Dbcontext.SaveChanges();
                return fav;

            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<List<Ressource>> GetRessourceListUser(int user)
        {
            try
            {
                var resources = await _Dbcontext.Ressource
                                 .Where(r => _Dbcontext.UserFavorite
                                     .Where(f => f.Id_User == user)
                                     .Select(f => f.ID_Ressource)
                                     .Contains(r.ID_Ressource))
                                 .ToListAsync();
                return resources;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
    }
}
