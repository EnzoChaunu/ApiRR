using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interfaces;
using System;
using Nest;

namespace RRelationnelle
{
    public class RolesRepository : IRolesRepository
    {
        private readonly RrelationnelApiContext _ctx;

        public RolesRepository(RrelationnelApiContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Archive(int id)
        {
            var entity = await _ctx.Role.FindAsync(id);
            
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.Activated = false;
                _ctx.Role.Update(entity);
                await _ctx.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> ArchiveByName(string name)
        {
            var entity = await _ctx.Role.FirstOrDefaultAsync(p => p.name == name);
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.Activated = false;
                _ctx.Role.Update(entity);
                await _ctx.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Roles> Create(Roles obj)
        {
            try
            {
                _ctx.Role.Add(obj);
                await _ctx.SaveChangesAsync();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Roles> Get(dynamic id)
        {
            try
            {
                var role = await _ctx.Role.FindAsync(id);
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync()
        {
            List<Roles> roles = new List<Roles>();
            roles = await _ctx.Role.ToListAsync();
            return roles;
        }

        public async Task<Roles> GetByName(string name)
        {
            try
            {
                var Role = await _ctx.Role.FirstOrDefaultAsync(p => p.name == name);
                return Role;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<ActionResult<Roles>> GetRoleByUserIdAsync(int id)
        {
            Roles UserRole = new Roles();
            UserRole = await _ctx.Role.FindAsync(id);
            return UserRole;
        }

        public async Task<Roles> Update(Roles obj, int id)
        {
            var entity = await _ctx.Role.FindAsync(id);
            entity.Activated = obj.Activated;
            entity.name = obj.name;
            _ctx.Role.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
    }
}
