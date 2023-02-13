using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        //private Categorie _entities;
        private readonly RrelationnelApiContext _ctx;

        public CategoryRepository(RrelationnelApiContext ctx)
        {
            _ctx = ctx;
        }

        public Roles CreateCategory(Roles category)
        {
            try
            {
                _ctx.Category.Add(category);
                _ctx.SaveChanges();
                return category;
            }
            catch
            {
                return null;
            }
        }

        //public IEnumerable<Categorie> ListCategory()
       // {
                
        //}

      public async Task<ActionResult<IEnumerable<Roles>>> ListCategory()
        {
             List<Roles> categorie = new List<Roles>();
            categorie = await _ctx.Category.ToListAsync();
            return categorie;
        }

        public async Task<IEnumerable<Roles>> ListCategory2()
        {
            List<Roles> categorie = new List<Roles>();
            categorie = await _ctx.Category.ToListAsync();
            return categorie;
        }
    }

}
