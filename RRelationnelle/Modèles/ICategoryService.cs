using RessourcesRelationelles.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Modèles
{
    public interface ICategoryService
    {
        bool CreateCategory(Categorie category);
        IEnumerable<Categorie> ListCategory();
    }
}
