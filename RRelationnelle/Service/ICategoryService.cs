using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface ICategoryService
    {
        CategoryDto CreateCategory(CategoryDto category);
        public Task<ActionResult<IEnumerable<CategoryDto>>> ListCategory();
        public Task<IEnumerable<CategoryDto>> ListCategory2();
    }
}
