using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface ICategoryRepository
    {
        public  Task<Categorie> GetByid(int id);
        Task<Categorie> CreateCategory(Categorie category);
        Task<Categorie> Update(Categorie category,int id);
        Task<bool> Archive(int id);
        public Task<ActionResult<IEnumerable<Categorie>>> ListCategory();
        public Task<IEnumerable<Categorie>> ListCategory2();

    }
}
