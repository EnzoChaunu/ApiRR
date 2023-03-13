using Microsoft.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RRelationnelle
{
    public class Categorie
    {
        [Key]
        public int Id_Category { get; set; }

        [Column]
        public string _name { get; set; }
        public bool isActive { get; set; } 
        public DateTime _creationDate { get; set; }

        [ForeignKey("Creator")]
        public int idcreator { get; set; }

        
        //public Admin Creator { get; set; }

        
    }
}