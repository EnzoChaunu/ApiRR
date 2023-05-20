using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RRelationnelle
{
    public class Comment
    {
        [Key]
        public int id_comments { get; set; }


        [ForeignKey("Id_User")]
        public User  id_user { get; set; }


        [ForeignKey("ID_Ressource")]
        public Ressource id_ressource { get; set; }
       

        [Column]
        public string content { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public bool activation { get; set; }
        public bool modified { get; set; }
        public DateTime creationDate { get; set; }
        
    }
}
