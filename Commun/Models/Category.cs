using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RRelationnelle
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Category { get; set; }

        [Column]
        public string _name { get; set; }
        public bool isActive { get; set; } 
        public DateTime _creationDate { get; set; }

        [ForeignKey("Id_User")]
        public User Creator { get; set; }
     

        public Category(string name, bool isact,User _creator)
        {
            _name = name;
            isActive = isact;
            Creator = _creator;
        }


        public Category()
        {
            
        }

        public Category(int id)
        {
            Id_Category = id;
        }
    }
}