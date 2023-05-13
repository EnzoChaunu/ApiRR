using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class CommentRepository : ICommentRepository
    {
        private readonly RrelationnelApiContext _ctx;
        private readonly IConfiguration _configuration;
        public CommentRepository(RrelationnelApiContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            _configuration = config;
        }

        public Task<bool> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Create(Comment obj)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Get(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Update(Comment obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
