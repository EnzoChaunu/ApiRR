using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        public int ID_Ressource { get; set; }

        public int Id_User { get; set; }

        public UserFavorite()
        {
            
        }

        public UserFavorite( Ressource res, User us)
        {
            ressource = res;
            user = us;
        }
    }
}
