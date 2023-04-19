using Business.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Diagnostics;
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

        public async Task<bool> Archive(int id)
        {
            var user = await _repos.Get(id);
            if (user != null)
            {
                return await _repos.Archive(id);
            }
            else
            {
                return false;
            }
        }

        //public async Task<bool> GetByEmail(string email) 
        //{
        //    var userEmail = await _repos.GetByEmail(email);
        //    if (userEmail != null) { return true; }
        //    else { return false; }
        //}

        //TODO : Parse exception en Json    
        public async Task<UserDto> Create(UserDto obj)
        {
            try
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

                        return user;
                    }
                    else
                    {
                        throw new Exception("Database operation failed");
                    }
                }
                else { throw new Exception(string.Format("User {0} already taken", obj.Email)); }
                
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<UserDto> Get(int id)
        {
            try
            {
                var mapper = MappingUser.UserMapper();
                var rep = await _repos.Get(id);
                if (rep != null)
                {
                    var user = mapper.Map<User, UserDto>(rep);
                    return user;
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

        public async Task<UserDto> Update(UserDto obj, int id)
        {
            if (_repos.Get(obj.Id) == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var mapper = MappingUser.UserMapper();
                    var userDb = mapper.Map<UserDto, User>(obj);
                    var rep = await _repos.Update(userDb, id);
                    if (rep != null)
                    {
                        var user = mapper.Map<User, UserDto>(rep);
                        return user;
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
