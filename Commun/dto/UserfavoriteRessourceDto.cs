using RRelationnelle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.dto
{
    public class UserfavoriteRessourceDto
    {

        public int _IdUserFav { get; set; }

        public RessourceDto _ressource { get; set; }

        public UserDto _user { get; set; }

        public UserfavoriteRessourceDto(RessourceDto ressource,UserDto user)
        {
            _ressource = ressource;
            _user = user;
        }

    }
}
