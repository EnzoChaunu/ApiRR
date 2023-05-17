using Business.Interfaces;
using Commun.Hash;
using Commun.Responses;
using DataAccess.Interfaces;
using Nest;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RRelationnelle.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repos;
        private readonly IRolesRepository _reposRole;
        public UserService(IUserRepo repo, IRolesRepository repoRole)
        {
            _repos = repo;
            _reposRole = repoRole;
        }

        public async Task<Response<bool>> Archive(int id)
        {
            try
            {
                var user = await _repos.Get(id);
                if (user != null)
                {
                    await _repos.Archive(user.Id_User);
                    return new Response<bool>
                                    (200, true, string.Format("user {0} successfully created!", user.Email));
                }
                else
                {
                    return new Response<bool>
                                    (404, false, "User not found.");
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>
                                    (500, false, ex.Message);
            }
        }

        //public async Task<bool> GetByEmail(string email) 
        //{
        //    var userEmail = await _repos.GetByEmail(email);
        //    if (userEmail != null) { return true; }
        //    else { return false; }
        //}

        public async Task<Response<UserDto>> Create(UserDto obj)
        {
            try
            {
                if (CheckEmail(obj.Email))
                {
                    var role = await _reposRole.Get(obj.IdRole);
                    var map = MappingUser.UserMapperDtoToModel(role);
                    obj.CreationDate= DateTime.Now;
                    obj.Activation = true;
                    User userDb = map.Map<UserDto, User>(obj);
                    
                    if (await _repos.GetByEmail(obj.Email) == null)
                    {
                        var rep = await _repos.Create(userDb);
                        if (rep != null)
                        {
                            map = MappingUser.UserMapperModelToDto();
                            UserDto user = map.Map<User, UserDto>(rep);

                            return new Response<UserDto>
                                (200, user, string.Format("user {0} successfully created!", user.Email));
                        }
                        else
                        {
                            return new Response<UserDto>
                                (500, null, "Communication failed with Database.");
                        }
                    }
                    else
                    {
                        return new Response<UserDto>
                                (500, null, string.Format("user {0} already exists", obj.Email));
                    }
                }
                else
                {
                    return new Response<UserDto>
                                (400, null, string.Format("email {0} invalid format.", obj.Email));
                }


            }
            catch (Exception ex)
            {
                return new Response<UserDto>
                                (500, null, ex.Message);
            }
        }

        public async Task<Response<UserDto>> Get(int id)
        {
            try
            {
                var mapper = MappingUser.UserMapperModelToDto();
                var rep = await _repos.Get(id);
                if (rep != null)
                {
                    var user = mapper.Map<User, UserDto>(rep);
                    return new Response<UserDto>(200, user, "");
                }
                else
                {
                    return new Response<UserDto>
                                    (404, null, string.Format("user {0} not found", id));
                }
            }
            catch (Exception ex)
            {
                return new Response<UserDto>
                                    (500, null, ex.Message);
            }
        }

        public async Task<Response<UserDto>> Update(UserDto obj, int id)
        {
            if (_repos.Get(obj.Id) == null)
            {
                return new Response<UserDto>
                                (404, null, string.Format("user {0} doesn't exists", obj.Email));
            }
            else
            {
                if (CheckEmail(obj.Email))
                {
                    try
                    {
                        var role = await _reposRole.Get(obj.IdRole);
                        var mapper = MappingUser.UserMapperDtoToModel(role);
                        var userDb = mapper.Map<UserDto, User>(obj);
                        var rep = await _repos.Update(userDb, id);
                        if (rep != null)
                        {
                            var user = mapper.Map<User, UserDto>(rep);
                            return new Response<UserDto>
                                (200, user, string.Format("User {0} successfully updated!", user.Email));
                        }
                        else
                        {
                            return new Response<UserDto>
                                (500, null, "Communication failed with Database.");
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Response<UserDto>
                                (500, null, ex.Message);
                    }
                }
                else
                {
                    return new Response<UserDto>
                                (400, null, string.Format("email {0} invalid format.", obj.Email));
                }
            }
        }

        //Can be tested
        public bool CheckEmail(string email)
        {
            string strRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                return true;
            else
                return false;
        }

        public async Task<Response<UserDto>> UpdateUserToken(int user, Response<string> token)
        {
            var hashToken = Hashing.HashToken(token.Data);
            var reponse = await _repos.UpdateUserToken(user, hashToken);
            if (reponse != null)
            {
               
                var map = MappingUser.UserMapperModelToDto();
                var us = map.Map<User, UserDto>(reponse);
                return new Response<UserDto>(200, us, "token modifié avec succès");
            }
            else
            {
                return new Response<UserDto>(400, null, "Erreur modification token");

            }
        }

        public async Task<Response<List<UserDto>>> GetUserListByRole(string role)
        {
            try
            {
                if (await _reposRole.GetByName(role) != null)
                {
                    var response = await _repos.GetUserListByRole(role);
                    var mapper = MappingUser.UserMapperModelToDto();
                    var list = mapper.Map<List<User>, List<UserDto>>(response);
                    if (list.Count < 0)
                        return new Response<List<UserDto>>(200, list, string.Format("Voici la liste de {0}", role));
                    else
                        return new Response<List<UserDto>>(500, list, string.Format("Aucune occurence pour Role {0}", role));
                }
                else
                {
                    return new Response<List<UserDto>>(500, null, string.Format("Erreur ! Role {0} n'existe pas", role));
                }
                
            }
            catch(Exception ex)
            {
                return new Response<List<UserDto>>
                                (500, null, ex.Message);
            }
            
        }
    }
}
