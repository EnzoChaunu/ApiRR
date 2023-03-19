using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<TType>
    {
        public Task<TType> Create(TType obj);
        public Task<TType> Update(TType obj, int id);
        public Task<bool> Archive(int id);
        public Task<TType> Get(int id);


    }
}
