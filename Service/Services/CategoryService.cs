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
        private readonly IUserRepo _user;
        //private readonly IRepository<Categorie> _repos;
        public CategoryService(ICategoryRepository repo, IUserRepo user)
        {
            _repos = repo;
            _user = user;
            // _validations =validations;
        }

        public void AddError(string key, string errorMessage)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> Archive(int id)
        {
            var categ = await _repos.ListCategory();
            if (categ != null)
            {
                if(await _repos.Archive(id) != true)
                {
                    return new Response<bool> (200, true, "Catégorie archivée" );
                }
                else
                {
                    return new Response<bool>(404, false, "Catégorie non-archivée");
                }
            }
            else
            {
                return new Response<bool>(404, false, "Catégorie non-trouvée");
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

        public async Task<Response<CategoryDto>> Create(CategoryDto category)
        {
            if (!CheckValues(category))
            {
                return null;
            }
            else
            {
                try
                {
                    User user =await _user.Get(category._creator);
                    var mapper = MappingCategory.MappingCategoryTomodel(user);
                    Category categorieDb = mapper.Map<CategoryDto, Category>(category);
                    var rep = await _repos.Create(categorieDb);
                    if (rep != null)
                    {
                         mapper = MappingCategory.MappingCategoryToDto();
                        CategoryDto Categ = mapper.Map<Category, CategoryDto>(rep);
                       return  new Response<CategoryDto>(200, Categ, "catégorie créée");
                    }
                    else
                    {
                        return new Response<CategoryDto>(404, null, "échec création catégorie");
                    }
                }
                catch
                {
                    return new Response<CategoryDto>(404, null, "échec création catégorie");
                }
            }
        }

        public Task<Response<CategoryDto>> Get(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<Response<CategoryDto>> Update(CategoryDto category, int id)
        {
            if (!CheckValues(category))
            {
                return null;
            }
            else
            {
                try
                {
                    User user = await _user.Get(category._creator);
                    var mapper = MappingCategory.MappingCategoryTomodel(user);
                    Category categorieDb = mapper.Map<CategoryDto, Category>(category);
                    var rep = await _repos.Update(categorieDb, id);
                    if (rep != null)
                    {
                        mapper = MappingCategory.MappingCategoryToDto();
                        CategoryDto Categ = mapper.Map<Category, CategoryDto>(rep);
                        return new Response<CategoryDto>(200, Categ, "Modification de catégorie réussie");

                    }
                    else
                    {
                        return new Response<CategoryDto>(404, null, "Echec Modification" );

                    }
                }
                catch
                {
                    return new Response<CategoryDto>(500, null, "Echec Modification");

                }
            }
        }

        public async Task<Response<List<CategoryDto>>> ListCategory2()
        {

            List<Category> categorie = await _repos.ListCategory();
            var mapper = MappingCategory.MappingCategoryToDto();
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
