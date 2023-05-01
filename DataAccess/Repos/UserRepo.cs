﻿using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RRelationnelle.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly RrelationnelApiContext _Dbcontext;
        private readonly IConfiguration _configuration;

        public UserRepo(RrelationnelApiContext context,IConfiguration config)
        {
            _Dbcontext = context;
            _configuration = config;
        }

        public async Task<bool> Archive(int id)
        {
            var entity = await _Dbcontext.User.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.Activation = false;
                _Dbcontext.User.Update(entity);
                await _Dbcontext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            var context = CreateDbContext();
            var user = await context.User.Include(r => r.Role).FirstOrDefaultAsync(e => e.Email == email);
            if (user == null) { return null; }
            else { return user; }
        }

        public async Task<User> Create(User obj)
        {
            try
            {
                _Dbcontext.User.Add(obj);
                await _Dbcontext.SaveChangesAsync();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        private RrelationnelApiContext CreateDbContext()
        {
            var connectionString = _configuration.GetConnectionString("ApiRessourceConnection");
            var optionsBuilder = new DbContextOptionsBuilder<RrelationnelApiContext>()
                .UseSqlServer(connectionString);

            return new RrelationnelApiContext(optionsBuilder.Options);
        }

        public async Task<User> Get(dynamic id)
        {
            var context = CreateDbContext();
            int _id = id;
            var user = await context.User.Include(r => r.Role).FirstOrDefaultAsync(r => r.Id_User == _id); ;
            return user;
        }

        public async Task<User> Update(User obj, int id)
        {
            try
            {
                var user = await _Dbcontext.User.FindAsync(id);
                user.Id_User = obj.Id_User;
                user.Activation = obj.Activation;
                user.Email = obj.Email;
                user.Password = obj.Password;
                user.Login = obj.Login;
                user.Role = obj.Role;
                user.CreationDate = obj.CreationDate;
                user.FName = obj.FName;
                user.LName = obj.LName;
                _Dbcontext.User.Update(user);
                await _Dbcontext.SaveChangesAsync();
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}
