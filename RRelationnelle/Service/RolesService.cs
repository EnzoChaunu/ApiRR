using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public class RolesService : IRolesService
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

        public async Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync()
        {
            List<Roles> roles = new List<Roles>();
            var r = await _repo.GetAllRolesAsync();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingRoles>();
            });

            var mapper = config.CreateMapper();
            List<Roles> rolesdto = new List<Roles>();
            // mapper.Map(List<Category>, List<Categorie>)(categ);
            return rolesdto;
        }
    }
}
