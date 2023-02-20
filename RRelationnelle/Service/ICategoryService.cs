using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CategoryDto category);
        Task<CategoryDto> UpdateCategory(CategoryDto category,int id);
        Task<bool> Archive(int id);
        public Task<ActionResult<IEnumerable<CategoryDto>>> ListCategory();
        public Task<IEnumerable<CategoryDto>> ListCategory2();
    }
}
