using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RRelationnelle
{
    public class Roles
    {
        [Key]
        public int id_role { get; set; }
        [Column]
        public string name { get; set; }
        [Column]
        public bool Activated { get; set; }
    }
}
