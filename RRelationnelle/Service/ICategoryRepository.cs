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
        Roles CreateCategory(Roles category);
        public Task<ActionResult<IEnumerable<Roles>>> ListCategory();
        public Task<IEnumerable<Roles>> ListCategory2();

    }
}
