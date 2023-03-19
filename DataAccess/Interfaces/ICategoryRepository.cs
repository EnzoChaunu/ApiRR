using Microsoft.AspNetCore.Mvc;
using RRelationnelle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<IEnumerable<Category>> ListCategory();
    }
}
