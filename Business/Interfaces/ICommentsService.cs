using Commun.Responses;
using RRelationnelle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICommentsService : IService<CommentDto>
    {
        public Task<Response<List<CommentDto>>> GetCommentsPerRessource(int id);
        public Task<Response<List<CommentDto>>> GetCommentsPerUser(int id);
        public Task<Response<CommentDto>> CreateWithToken(CommentDto obj, string expediteur);
    }
}
