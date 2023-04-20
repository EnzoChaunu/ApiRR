using Business.Interfaces;
using Commun.Responses;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommentsService : ICommentsService
    {
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

        public async Task<Response<List<CommentDto>>> GetCommentsPerRessource(int id)
        {
            return  new Response<List<CommentDto>>(200, null, "Echec ajout de vue");
        }

        public Task<Response<CommentDto>> Update(CommentDto obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
