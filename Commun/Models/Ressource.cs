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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Ressource { get; set; }

        [Column]
        public string _title { get; set; }
        [NotMapped]
        public int _Idcategory { get; set; }
     
        [ForeignKey("Id_Category")]
        public Category category { get; set; }
        public bool _activation { get; set; }
        public string _reference { get; set; }
        public int _views { get; set; }
        public DateTime _creationDate { get; set; }
        public string _url { get; set; }

        [ForeignKey("Id_User")]
        public User modification { get; set; }
        [NotMapped]
        public int _user { get; set; }

       public static List<Comment> _comments = new List<Comment>();

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

        */
        public Ressource(string reference,string title, int categ,string url,int user)
        {
            _reference = reference;
            _title = title;
            _Idcategory = categ;
            _url = url;
           _user = user;
        }

        public Ressource()
        {

        }
    }
}
