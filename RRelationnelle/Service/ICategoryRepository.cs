using Microsoft.AspNetCore.Mvc;
using RessourcesRelationelles.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public interface ICategoryRepository
    {
        Categorie CreateCategory(Categorie category);
        public Task<ActionResult<IEnumerable<Categorie>>> ListCategory();
        public Task<IEnumerable<Categorie>> ListCategory2();

    }
}
