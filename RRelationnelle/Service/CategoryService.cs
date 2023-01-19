using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryValidation _validations { get; set; }
        private ICategoryRepository _repos { get; set; }

        public CategoryService(ICategoryRepository _repo, ICategoryValidation _validation)
        {
            _validations = _validation;
            _repos = _repo;
        }


        protected bool ValidateCategory(Categorie categorie)
        {
            if (categorie._name == "")
            {
                _validations.AddError("name", "Veuillez rentrer un nom");
            }
            return _validations.IsValid;
        }

        public bool CreateCategory(Categorie category)
        {
            
                if (!ValidateCategory(category))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        _repos.CreateCategory(category);
                    }
                    catch
                    {
                        return false;
                    }
                    return true;
                }
            

          
               
            }

        public IEnumerable<Categorie> ListCategory()
        {
            
                return _repos.ListCategory();
            
        }
    }

      
    }
