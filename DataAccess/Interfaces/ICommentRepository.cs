using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public Task<bool> Archive(int id);

        public Task<Comment> Create(Comment obj);

        public Task<Comment> Get(dynamic id);

        public Task<Comment> Update(Comment obj, int id);
    }
}
