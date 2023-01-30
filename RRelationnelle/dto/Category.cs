using System;

namespace RRelationnelle.Modèles
{
    public class Category : ICategoryValidation
    {

        public int Id_Category { get; set; }
        public int _creator { get; set; }
        public string _name { get; set; }
        public User user { get; set; }
        public DateTime _creationDate { get; set; }

        public bool IsValid { get; set; }

        public Category(int id, string name, int creator, DateTime creationDate)
        {
            Id_Category = id;
            _name = name;
            _creator = creator;
            _creationDate = creationDate;
        }

        public void AddError(string key, string errorMessage)
        {
            if (errorMessage != "")
            {
                IsValid = false;
            }else
            {
                IsValid = true;
            }
        }







        // public string Name { get { return _name; } set { _name = value; } }



    }
}
