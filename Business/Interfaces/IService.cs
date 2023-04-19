using Commun.Responses;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface IService<TType>
    {
        public Task<Response<TType>> Create(TType obj);
        public Task<Response<TType>> Update(TType obj, int id);
        public Task<Response<TType>> Archive(int id);
        public Task<Response<TType>> Get(int id);
    }
}
