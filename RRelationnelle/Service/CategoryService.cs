using Microsoft.AspNetCore.Mvc;
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
        private readonly ICategoryValidation _validations;
        private readonly ICategoryRepository _repos;
        public CategoryService(ICategoryRepository repo, ICategoryValidation validations)
        {
            _repos = repo;
            _validations =validations;
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

        public async Task<ActionResult<IEnumerable<Categorie>>> ListCategory()
        {
            return await _repos.ListCategory();
        }



        // public IEnumerable<Categorie> ListCategory()
        //{

        // }



        protected bool ValidateCategory(Category categorie)
        {
            if (categorie._name == "")
            {
                categorie.AddError("name", "Veuillez rentrer un nom");
            }
            return categorie.IsValid;
        }



    }

      
    }
