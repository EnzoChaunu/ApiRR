using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Business.Interfaces;
using Commun.dto;

namespace RRelationnelle
{
    public class RolesService : IRoleService
    {
        private readonly IRolesRepository _repo;
        private readonly IUserRepo _repoUser;

        public RolesService(IRolesRepository repo)
        {
            _repo = repo;
            // _validations =validations;
        }

        public async Task<ActionResult<Roles>> GetRoleByUserIdAsync(int id)
        {
            try
            {
                var mapper = MappingRoles.MappingUserLog();
                //var userDb = mapper.Map<UserDto, User>();
                var rep = await _repoUser.Get(id);
                if (rep != null)
                {
                    var user = mapper.Map<User, UserDto>(rep);
                    var role = await _repo.Get(user.IdRole);
                    return role;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<RolesDto>> GetAllRolesAsync()
        {
            //List<Roles> roles = new List<Roles>();
            //var r = await _repo.GetAllRolesAsync();
            //roles = r.toList();
            //var mapper = MappingCategory.MappingCategoryL();
            //List<CategoryDto> categoriedto = mapper.Map<List<Category>, List<CategoryDto>>(categorie);
            //return categoriedto;
            throw new System.NotImplementedException();
        }

        public async Task<bool> Archive(int id)
        {
            var role = await _repo.Get(id);
            if (role == null)
            {
                return false;
            }
            else
            {
                await _repo.Archive(id);
                return true;
            }
        }

        public async Task<RolesDto> Create(RolesDto obj)
        {
            if (await _repo.GetByName(obj.name) == null)
            {
                try
                {
                    var mapper = MappingRoles.RolesMapper();
                    var roleDb = mapper.Map<RolesDto, Roles>(obj);
                    var rep = await _repo.Create(roleDb);
                    if (rep != null)
                    {
                        var role = mapper.Map<Roles, RolesDto>(rep);
                        return role;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<RolesDto> Update(RolesDto obj, int id)
        {
            if (_repo.Get(id) == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var mapper = MappingRoles.RolesMapper();
                    var roleDb = mapper.Map<RolesDto, Roles>(obj);
                    var rep = await _repo.Update(roleDb, id);
                    if (rep != null)
                    {
                        var role = mapper.Map<Roles, RolesDto>(rep);
                        return role;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public async Task<RolesDto> Get(int id)
        {
            try
            {
                var mapper = MappingRoles.RolesMapper();
                var rep = await _repo.Get(id);
                if (rep != null)
                {
                    var role = mapper.Map<Roles, RolesDto>(rep);
                    return role;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
