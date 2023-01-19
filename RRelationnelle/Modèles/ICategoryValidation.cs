using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Modèles
{
    public interface ICategoryValidation
    {
        void AddError(string key, string errorMessage);
        bool IsValid{ get; }
    }
}
