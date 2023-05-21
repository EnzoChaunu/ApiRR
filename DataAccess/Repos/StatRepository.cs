using Commun.Responses;
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
    public class StatRepository : IStatsRepo
    {

        private readonly RrelationnelApiContext _Dbcontext;


        public StatRepository(RrelationnelApiContext ctx)
        {
            _Dbcontext = ctx;
          
        }
        public Task<bool> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Stats> Create(Stats obj)
        {
            throw new NotImplementedException();
        }

        public Task<Stats> Get(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Stats>> GetStat()
        {
            throw new NotImplementedException();
        }

        public Task<Stats> Update(Stats obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
