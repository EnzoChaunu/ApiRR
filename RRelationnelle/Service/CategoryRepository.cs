using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public class CategoryRepository : ICategoryRepository
    {
        //private Categorie _entities;
        private readonly RrelationnelApiContext _ctx;

        public CategoryRepository(RrelationnelApiContext ctx)
        {
            _ctx = ctx;
        }

        public Categorie CreateCategory(Categorie category)
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

      public async Task<ActionResult<IEnumerable<Categorie>>> ListCategory()
        {
             List<Categorie> categorie = new List<Categorie>();
            categorie = await _ctx.Category.ToListAsync();
            return categorie;
        }

        public async Task<IEnumerable<Categorie>> ListCategory2()
        {
            List<Categorie> categorie = new List<Categorie>();
            categorie = await _ctx.Category.ToListAsync();
            return categorie;
        }
    }

}
