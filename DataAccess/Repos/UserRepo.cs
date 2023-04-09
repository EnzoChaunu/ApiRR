using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace RRelationnelle.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly RrelationnelApiContext _Dbcontext;

        public UserRepo(RrelationnelApiContext context)
        {
            _Dbcontext = context;
        }

        public async Task<bool> Archive(int id)
        {
            var entity = await _Dbcontext.User.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.Activation = false;
                _Dbcontext.User.Update(entity);
                await _Dbcontext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<User> Create(User obj)
        {
            try
            {
                _Dbcontext.User.Add(obj);
                await _Dbcontext.SaveChangesAsync();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> Get(dynamic id)
        {
            var user = await _Dbcontext.User.FindAsync(id);
            return user;
        }

        public async Task<User> Update(User obj, int id)
        {
            try
            {
                var user = await _Dbcontext.User.FindAsync(id);
                user.Id_User = obj.Id_User;
                user.Activation = obj.Activation;
                user.Email = obj.Email;
                user.Password = obj.Password;
                user.Login = obj.Login;
                user.Role = obj.Role;
                user.CreationDate = obj.CreationDate;
                user.FName = obj.FName;
                user.LName = obj.LName;
                _Dbcontext.User.Update(user);
                await _Dbcontext.SaveChangesAsync();
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}
