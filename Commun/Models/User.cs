using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RRelationnelle
{
    public class User
    {
     
        [Key]
        public int Id_User { get; set; }

        [Column]
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public bool Activation { get; set; }
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public int IdRole { get; set; }

        [ForeignKey("id_role")]
        public Roles Role { get; set; }
    }
}