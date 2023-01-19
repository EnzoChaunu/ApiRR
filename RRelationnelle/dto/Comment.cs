

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// commmm
namespace RessourcesRelationelles.Class
{
    public class Comments
    {
        [Key]
        public int id_comments { get; set; }


        [ForeignKey("Id_User")]
        public User  id_user { get; set; }

        [ForeignKey("ID_Ressource")]
        public Ressource id_ressource { get; set; }

        public string content { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public bool activation { get; set; }
        public bool modified { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }

        //public int Id { get { return _id; } }
        // public string Content { get { return _content; } set { _content = value; } }


    }
}
