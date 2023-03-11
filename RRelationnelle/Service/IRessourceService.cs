using Microsoft.AspNetCore.Mvc;
using RRelationnelle.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public interface IRessourceService
    {
        public Task<List<RessourceDto>> GetFormation(string rome, string romeDomain, string caller);
        public Task<ActionResult<RessourceDto>> Create();
        public Task<ActionResult<bool>> Delete();

    }
}
