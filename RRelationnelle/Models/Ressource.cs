using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RessourcesRelationelles.Class
{
    public class Ressource
    {
        
        [Key]
        public int ID_Ressource { get; set; }

        [Column]
        public string _title { get; set; }
        public string _description { get; set; }
        public string _content { get; set; }

        [ForeignKey("Id_Category")]
        public Roles category { get; set; }
        //public Category Id_Category { get; set; }
        public bool _activation { get; set; }
        //private User _modification;

        public int _views { get; set; }
        public DateTime _creationDate { get; set; }
        public string _url { get; set; }


       // private List<Comments> _comments = new List<Comments>();
    }
}
