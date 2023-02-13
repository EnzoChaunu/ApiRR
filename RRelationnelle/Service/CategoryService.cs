using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RessourcesRelationelles.Class;
using RRelationnelle.Mapping;
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
        public CategoryService(ICategoryRepository repo)
        {
            _repos = repo;
           // _validations =validations;
        }


       public Category CreateCategory(Category category)
        {
         
            if (ValidateCategory(category) != 0)
            {
                return null;
            }
            else
            {
                try
                {
                    var mapper = MappingCategory.MappingCategoryL();
                    Roles categorieDb = mapper.Map<Category, Roles>(category);
                    var rep = _repos.CreateCategory(categorieDb);
                    if (rep != null)
                    {
                    Category Categ = mapper.Map<Roles, Category>(rep);
                        return Categ;
                    }
                    else
                    {
                        return null;
                    }

                }
                catch
                {
                    return null;
                }
               
            }
        }

        public async Task<ActionResult<IEnumerable<Category>>> ListCategory()
        {
            List<Roles> categorie = new List<Roles>();
            var categ = await _repos.ListCategory2();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingCategory>();
            });

            var mapper = config.CreateMapper();
            List<Category> categoriedto= new List<Category>(); 
           // mapper.Map(List<Category>, List<Categorie>)(categ);
            return categoriedto;
            
        }

       



        // public IEnumerable<Categorie> ListCategory()
        //{

        // }



        protected int ValidateCategory(Category categorie)
        {
            if (categorie._name == "")
            {
               return categorie.Id_Category;
            }
            else
            {
             return 0;
            }
        }

         async Task<IEnumerable<Category>> ICategoryService.ListCategory2()
        {

            List<Roles> categorie = new List<Roles>();
            var categ = await _repos.ListCategory2();
            categorie = categ.ToList();
            var mapper = MappingCategory.MappingCategoryL();
            List<Category> categoriedto = mapper.Map<List<Roles>,List<Category>>(categorie);
            return categoriedto;
        }
    }

      
    }
