using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class CommentRepository : ICommentRepository
    {
        private readonly RrelationnelApiContext _ctx;
        private readonly IConfiguration _configuration;
        public CommentRepository(RrelationnelApiContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            _configuration = config;
        }

        public async Task<bool> Archive(int id)
        {
            try
            {
                var entity = await _ctx.Comments.FindAsync(id);
                entity.activation = false;
                _ctx.Comments.Update(entity);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        private RrelationnelApiContext CreateDbContext()
        {
            var connectionString = _configuration.GetConnectionString("ApiRessourceConnection");
            var optionsBuilder = new DbContextOptionsBuilder<RrelationnelApiContext>()
                .UseSqlServer(connectionString);

            return new RrelationnelApiContext(optionsBuilder.Options);
        }

        public async Task<Comment> Create(Comment obj)
        {
            try
            {
                
                //context.Entry(obj.id_user).State = EntityState.Unchanged;
                await  _ctx.Comments.AddAsync(obj);
                await _ctx.SaveChangesAsync();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Comment> Get(dynamic id)
        {
            try
            {
                var comment = await _ctx.Comments.FindAsync(id);
                return comment;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<Comment> Update(Comment obj, int id)
        {
            try
            {
                var entity = await _ctx.Comments.FindAsync(id);
                entity.content = obj.content;
                entity.activation = obj.activation;
                entity.modified = true;
                entity.likes = obj.likes;
                entity.dislikes = obj.dislikes;
                entity.creationDate = obj.creationDate;
                entity.id_ressource = obj.id_ressource;
                entity.id_user= obj.id_user;
                _ctx.Comments.Update(entity);
                await _ctx.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<List<Comment>> GetCommentListPerResource(int id)
        {
            try
            {
                var comments = await _ctx.Comments.Include(c => c.id_user).Where(c => c.id_ressource.ID_Ressource == id).ToListAsync();
                return comments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<Comment>> GetCommentListPerUser(int id)
        {
            try
            {
                var comments = await _ctx.Comments.Include(c => c.id_user).Where(c => c.id_user.Id_User == id).ToListAsync();
                return comments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CountComments()
        {
            try
            {
                return await _ctx.Comments.CountAsync();
            }
            catch

            {
                return 0;
            }
        }
    }
}
