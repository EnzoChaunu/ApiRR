using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Models
{
    public class UserFavorite
    {
        [Key]
        public int  IdUserFav { get; set; }

        [ForeignKey("ID_Ressource")]
        public Ressource ressource { get; set; }

        [ForeignKey("Id_User")]
        public User user { get; set; }
    }
}
