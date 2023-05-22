using Business.Interfaces;
using Commun.Responses;
using DataAccess.Interfaces;
using RRelationnelle;
using RRelationnelle.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StatsService : IStatService
    {
        private readonly IRessourceRepo _repo;
        private readonly ICommentRepository _commentrepo;
        private readonly IUserRepo _user;
        public StatsService(IRessourceRepo rep, ICommentRepository comment, IUserRepo user)
        {
            _repo = rep;
            _commentrepo = comment;
            _user = user;
        }
        public Task<Response<bool>> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<StatsDto>> Create(StatsDto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Response<StatsDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<StatsDto>> GetStat()
        {
            try
            {
                var Stat = new StatsDto
                {
                    _visits = await _repo.CountView(),
                    _favorite = await _repo.CountFavorites(),
                    _Shared = await _repo.CountShared(),
                    _accountsCreated = await _user.CountAccounts(),
                    _commentPosted =await _commentrepo.CountComments()

                };

                return new Response<StatsDto>(200, Stat, "Statistiques à jours");

            }
            
            catch (Exception ex)
            {
                return new Response<StatsDto>(500, null, ex.Message);


            }
        }

        public Task<Response<StatsDto>> Update(StatsDto obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
