using Business.Interfaces;
using Commun.Responses;
using DataAccess.Interfaces;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommentService : ICommentsService
    {
        private readonly ICommentRepository _repos;
        private readonly IUserRepo _user;
        private readonly IRessourceRepo _ressource;
        public CommentService(ICommentRepository repo, IUserRepo user, IRessourceRepo ressource)
        {
            _repos = repo;
            _user = user;
            _ressource = ressource;
        }

        public Task<Response<bool>> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CommentDto>> Create(CommentDto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CommentDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<CommentDto>>> GetCommentsPerRessource(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CommentDto>> Update(CommentDto obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
