﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public class CategoryService : ICategoryService,ICategoryValidation
    {
        
        private readonly ICategoryRepository _repos;
        public CategoryService(ICategoryRepository repo)
        {
            _repos = repo;
           // _validations =validations;
        }

        public void AddError(string key, string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool CheckValues(CategoryDto categ)
        {
            if (categ._name == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto category)
        {
            
            if (!CheckValues(category))
            {
                return null;
            }
            else
            {
                try
                {
                    var mapper = MappingCategory.MappingCategoryL();
                    Categorie categorieDb = mapper.Map<CategoryDto, Categorie>(category);
                    var rep = await  _repos.CreateCategory(categorieDb);
                    if (rep != null)
                    {
                    CategoryDto Categ = mapper.Map<Categorie, CategoryDto>(rep);
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

        public async Task<ActionResult<IEnumerable<CategoryDto>>> ListCategory()
        {
            List<Roles> categorie = new List<Roles>();
            var categ = await _repos.ListCategory2();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingCategory>();
            });

            var mapper = config.CreateMapper();
            List<CategoryDto> categoriedto= new List<CategoryDto>(); 
           // mapper.Map(List<Category>, List<Categorie>)(categ);
            return categoriedto;
            
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto category,int id)
        {
            if (!CheckValues(category))
            {
                return null;
            }
            else
            {
                try
                {
                    var mapper = MappingCategory.MappingCategoryL();
                    Categorie categorieDb = mapper.Map<CategoryDto, Categorie>(category);
                    var rep = await _repos.Update(categorieDb,id);
                    if (rep != null)
                    {
                        CategoryDto Categ = mapper.Map<Categorie, CategoryDto>(rep);
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


         async Task<IEnumerable<CategoryDto>> ICategoryService.ListCategory2()
        {

            List<Categorie> categorie = new List<Categorie>();
            var categ = await _repos.ListCategory2();
            categorie = categ.ToList();
            var mapper = MappingCategory.MappingCategoryL();
            List<CategoryDto> categoriedto = mapper.Map<List<Categorie>,List<CategoryDto>>(categorie);
            return categoriedto;
        }
    }

      
    }
