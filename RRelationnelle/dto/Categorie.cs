using Microsoft.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RessourcesRelationelles.Class
{
    public class Categorie
    {
        [Key]
        public int Id_Category { get; set; }
        [Column]
        public string _name { get; set; }
        public DateTime _creationDate { get; set; }
        [ForeignKey("Creator")]
        public int idcreator { get; set; }
        //public Admin Creator { get; set; }

        public Categorie (string name,DateTime creation,int creator)
        {
            _name = name;
            creation = _creationDate;
            idcreator = creator;
        }
    }
}