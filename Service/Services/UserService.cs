using Business.Interfaces;
using Commun.Responses;
using DataAccess.Interfaces;
using System;
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
                                    (400, false, ex.Message);
            }
        }

        //public async Task<bool> GetByEmail(string email) 
        //{
        //    var userEmail = await _repos.GetByEmail(email);
        //    if (userEmail != null) { return true; }
        //    else { return false; }
        //}

        //TODO : Parse excresponeption en Json    
        public async Task<Response<UserDto>> Create(UserDto obj)
        {
            try
            {
                if (CheckEmail(obj.Email))
                {
                    var map = MappingUser.UserMapper();
                    var role = await _reposRole.Get(obj.IdRole);
                    obj.Role = role;
                    User userDb = map.Map<UserDto, User>(obj);
                    if (await _repos.GetByEmail(obj.Email) == null)
                    {
                        var rep = await _repos.Create(userDb);
                        if (rep != null)
                        {
                            UserDto user = map.Map<User, UserDto>(rep);

                            return new Response<UserDto>
                                (200, user, string.Format("user {0} successfully created!", user.Email));
                        }
                        else
                        {
                            return new Response<UserDto>
                                (400, null, "Communication failed with Database.");
                        }
                    }
                    else {
                        return new Response<UserDto>
                                (404, null, string.Format("user {0} doesn't exists", obj.Email));
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
                                (400, null, ex.Message);
            }
        }

        public async Task<Response<UserDto>> Get(int id)
        {
            try
            {
                var mapper = MappingUser.UserMapper();
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
            catch(Exception ex)
            {
                return new Response<UserDto>
                                    (400, null, ex.Message);
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
                if(CheckEmail(obj.Email))
                {
                    try
                    {
                        var mapper = MappingUser.UserMapper();
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
                                (400, null, "Communication failed with Database.");
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    return new Response<UserDto>
                                (400, null, string.Format("email {0} invalid format.", obj.Email));
                }
                
            }
        }

        public bool CheckEmail(string email)
        {
            string strRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                return true;
            else
                return false;
        }
    }
}
