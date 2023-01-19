//using EntityFrameworkCore;
using System.Collections.Generic;

namespace RessourcesRelationelles.Class
{
    public class Mod : User
    {
        private List<Citizen> _citizens = new List<Citizen>();
        private List<Comments> _comments = new List<Comments>();

        public void DeleteCom()
        {

        }
    }
}
