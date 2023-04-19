﻿using Microsoft.AspNetCore.Mvc;
using RRelationnelle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRolesRepository : IRepository<Roles>
    {
       public Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync();
       public Task<Roles> GetByName(string name);
       public Task<bool> ArchiveByName(string name);

    }
}
