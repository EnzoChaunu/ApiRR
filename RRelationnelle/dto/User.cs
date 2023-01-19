using RRelationnelle.dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace RessourcesRelationelles.Class
{
    public class User
    {
     
        [Key]
        public int Id_User { get; set; }

        [Column]
        public string _fName { get; set; }
        public string _lName { get; set; }
        public string _email { get; set; }
        public string _password { get; set; }
        public string _login { get; set; }
        public bool _activation { get; set; }
        public DateTime _creationDate { get; set; }

        [ForeignKey("id_role")]
        public Roles Role { get; set; }



    }
}
