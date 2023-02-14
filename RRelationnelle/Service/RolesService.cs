using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRelationnelle.Service
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
           /* List<Roles> roles = new List<Roles>();
            var categ = await _repos.ListCategory2();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingCategory>();
            });

            var mapper = config.CreateMapper();
            List<Category> categoriedto = new List<Category>();
            // mapper.Map(List<Category>, List<Categorie>)(categ);
            return categoriedto;*/
        }

        public async Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync()
        {
            return null;
        }
    }
}
