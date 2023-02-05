using System;

namespace RRelationnelle.Modèles
{
    public class Category 
    {

        public int Id_Category { get; }
        public int _creator { get; set; }
        public string _name { get; set; }
        private User user { get; }
        public DateTime _creationDate { get;}

        public bool IsValid {get;}

     /*   public Category(int id, string name, int creator, DateTime creationDate)
        {
            Id_Category = id;
            _name = name;
            _creator = creator;
            _creationDate = creationDate;
        }*/

       /* public void AddError(string key, string errorMessage)
        {
            if (errorMessage != "")
            {
                IsValid = false;
            }else
            {
                IsValid = true;
            }
        }*/







        // public string Name { get { return _name; } set { _name = value; } }



    }
}
