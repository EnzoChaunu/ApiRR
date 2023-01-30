using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RessourcesRelationelles.Class;
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

        public bool CreateCategory(Categorie category)
        {
            try
            {
                _ctx.Category.Add(category);
                _ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public IEnumerable<Categorie> ListCategory()
       // {
                
        //}

      public async Task<ActionResult<IEnumerable<Categorie>>> ListCategory()
        {
            return await _ctx.Category.ToListAsync();
        }
    }

}
