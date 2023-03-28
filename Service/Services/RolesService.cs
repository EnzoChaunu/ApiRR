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

        public RolesService(IRolesRepository repo)
        {
            _repo = repo;
            // _validations =validations;
        }

        public async Task<ActionResult<Roles>> GetRoleByUserIdAsync(int id)
        {
            return null;
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

        public Task<RolesDto> Create(RolesDto obj)
        {
            //if(_repo.Get(obj.id_role) == null)
            //{
            //    var mapper = MappingRoles.
            //}
            //else
            //{
            //    return null;
            //}
            throw new System.NotImplementedException();
        }

        public Task<RolesDto> Update(RolesDto obj, int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RolesDto> Get(int id)
        {
            //var role = await _repo.Get(id);
            //return role;
            throw new System.NotImplementedException();

        }
    }
}
