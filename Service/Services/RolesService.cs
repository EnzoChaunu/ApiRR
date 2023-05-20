using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Business.Interfaces;
using Commun.dto;
using Commun.Responses;
using System;

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

        public async Task<Response<RolesDto>> GetRoleByUserIdAsync(int id)
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
                    var roleDto = mapper.Map<Roles, RolesDto>(role);
                    return new Response<RolesDto>
                                    (200, roleDto, string.Format("User {0} is {1}", user.Email, roleDto));
                }
                else
                {
                    return new Response<RolesDto>
                                    (404, null, "Role not found.");
                }
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<Response<RolesDto>> GetAllRolesAsync()
        {
            //List<Roles> roles = new List<Roles>();
            //var r = await _repo.GetAllRolesAsync();
            //roles = r.toList();
            //var mapper = MappingCategory.MappingCategoryL();
            //List<CategoryDto> categoriedto = mapper.Map<List<Category>, List<CategoryDto>>(categorie);
            //return categoriedto;
            throw new System.NotImplementedException();
        }

        //Test OK
        public async Task<Response<bool>> ArchiveByName(string roleName)
        {
            try
            {
                var role = await _repo.GetByName(roleName);
                if (role == null)
                {
                    return new Response<bool>
                        (404, false, string.Format("Role {0} doesn't exist.", roleName));
                }
                else
                {
                    await _repo.ArchiveByName(roleName);
                    return new Response<bool>
                        (200, true, string.Format("Role {0} archived.", roleName));
                }
            }
            catch(Exception ex) 
            {
                return new Response<bool>
                                    (500, false, ex.Message);
            }
        }

        //public async Task<Response<RolesDto>> CreateOrUpdate(RolesDto role)
        //{

        //}

        //Test OK
        public async Task<Response<RolesDto>> Create(RolesDto obj)
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
                        return new Response<RolesDto>
                            (200, role, string.Format("Role {0} successfully created.", role.name));
                    }
                    else
                    {
                        return new Response<RolesDto>
                            (500, null, string.Format("Role {0} creation failed.", obj.name));
                    }
                }
                catch(Exception ex)
                {
                    return new Response<RolesDto>
                        (500, null, ex.Message);
                }
            }
            else
            {
                return new Response<RolesDto>
                    (500, null, string.Format("Role {0} already exists.", obj.name));
            }
        }

        //Test OK
        public async Task<Response<RolesDto>> Update(RolesDto obj, int id)
        {
            var roleToUpdate = await _repo.Get(id);
            if (roleToUpdate == null)
            {
                return new Response<RolesDto>
                        (404, null, string.Format("Role {0} doesn't exist.", obj.name));
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
                        return new Response<RolesDto>
                            (200, role, string.Format("Role {0} successfully.", role.name));
                    }
                    else
                    {
                        return new Response<RolesDto>
                            (404, null, "Connection to Database failed.");
                    }
                }
                catch(Exception ex)
                {
                    return new Response<RolesDto>
                        (500, null, ex.Message);
                }
            }
        }

        //Test OK
        public async Task<Response<RolesDto>> Get(int id)
        {
            try
            {
                var mapper = MappingRoles.RolesMapper();
                var rep = await _repo.Get(id);
                if (rep != null)
                {
                    var role = mapper.Map<Roles, RolesDto>(rep);
                    return new Response<RolesDto>
                        (200, role, string.Format("Role {0} successfully loaded.", role.name));
                }
                else
                {
                    return new Response<RolesDto>
                        (404, null, "Role doesn't exist.");
                }
            }
            catch(Exception ex)
            {
                return new Response<RolesDto>
                    (500, null, ex.Message);
            }
        }

        //Test OK
        public async Task<Response<bool>> Archive(int id)
        {
            var role = await _repo.Get(id);
            if (role == null)
            {
                return new Response<bool>
                        (404, false, "Role doesn't exist.");
            }
            else
            {
                await _repo.Archive(id);
                return new Response<bool>
                        (200, true, string.Format("Role {0} successfully archived.", role.name));
            }
        }
    }
}
