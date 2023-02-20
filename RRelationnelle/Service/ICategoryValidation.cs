using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface ICategoryValidation
    {
        void AddError(string key, string errorMessage);
        bool CheckValues(CategoryDto categ);
    }
}
