using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RessourcesRelationelles.Class
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public interface IRolesRepository
    {
        //evolution possible : methode create
        public Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync();
        
        public Task<ActionResult<Roles>> GetRoleByUserIdAsync(int id);


    }
}
