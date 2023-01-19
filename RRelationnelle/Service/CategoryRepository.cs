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
    public class CategoryRepository : Modèles.ICategoryRepository
    {
        private Categorie _entities;
        private readonly RrelationnelApiContext _ctx;

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

        public IEnumerable<Categorie> ListCategory()
        {
                return _ctx.Category.ToList();
        }
    }

}
