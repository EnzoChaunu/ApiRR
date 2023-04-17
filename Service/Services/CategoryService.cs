using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Business.Interfaces;
using Commun.Responses;

namespace RRelationnelle
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repos;
        //private readonly IRepository<Categorie> _repos;
        public CategoryService(ICategoryRepository repo)
        {
            _repos = repo;
            // _validations =validations;
        }

        public void AddError(string key, string errorMessage)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Archive(int id)
        {
            var categ = await _repos.ListCategory();
            if (categ != null)
            {
                return await _repos.Archive(id);
            }
            else
            {
                return false;
            }
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

        public async Task<CategoryDto> Create(CategoryDto category)
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
                    Category categorieDb = mapper.Map<CategoryDto, Category>(category);
                    var rep = await _repos.Create(categorieDb);
                    if (rep != null)
                    {
                        CategoryDto Categ = mapper.Map<Category, CategoryDto>(rep);
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

        public Task<CategoryDto> Get(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<CategoryDto> Update(CategoryDto category, int id)
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
                    Category categorieDb = mapper.Map<CategoryDto, Category>(category);
                    var rep = await _repos.Update(categorieDb, id);
                    if (rep != null)
                    {
                        CategoryDto Categ = mapper.Map<Category, CategoryDto>(rep);
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

        public async Task<Response<List<CategoryDto>>> ListCategory2()
        {

            List<Category> categorie = await _repos.ListCategory();
            var mapper = MappingCategory.MappingCategoryL();
            List<CategoryDto> categoriedto = mapper.Map<List<Category>, List<CategoryDto>>(categorie);

            if (categoriedto != null)
            {
                return new Response<List<CategoryDto>> (200, categoriedto.ToList(), "Données trouvées" );
            }
            else if (categoriedto == null)
            {
                return new Response<List<CategoryDto>>(404, null, "Not found");

            }
            else
            {
                return new Response<List<CategoryDto>>(500, null, "Another statut code");

            }


        }
    }
}
