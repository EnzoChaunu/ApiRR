using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Responses
{
    public class Response <T>
    {
        public int ResponseCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public Response(int reponsecod,T donnee,string msg)
        {
            ResponseCode = reponsecod;
            Data = donnee;
            Message = msg;
        }


    }
}
