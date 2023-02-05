using Microsoft.AspNetCore.Mvc;
using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);
        public Task<ActionResult<IEnumerable<Category>>> ListCategory();
        public Task<IEnumerable<Category>> ListCategory2();
    }
}
