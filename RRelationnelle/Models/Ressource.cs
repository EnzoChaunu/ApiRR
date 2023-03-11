using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RRelationnelle
{
    public class Ressource
    {
        
        [Key]
        public int ID_Ressource { get; set; }

        [Column]
        public string _title { get; set; }
     
        [ForeignKey("Id_Category")]
        public Categorie category { get; set; }
        //public Category Id_Category { get; set; }
        public bool _activation { get; set; }
        //private User _modification;
        public string _reference { get; set; }
        public int _views { get; set; }
        public DateTime _creationDate { get; set; }
        public string _url { get; set; }

        public User modification { get; set; }

       public List<Comments> _comments = new List<Comments>();

       /* public Ressource(string id, string title, Categorie categ, bool activation, User _modification, int views, string url, List<Comments> comments)
        {
            ID_Ressource = id;
            _title = title;
            category = categ;
            _activation = activation;
             modification= _modification;
            _views = views;
            _url = url;
            _comments = comments;
        }


        public Ressource(string id, string title, Categorie categ)
        {
            ID_Ressource = id;
            _title = title;
            category = categ;
        }*/
    }
}
