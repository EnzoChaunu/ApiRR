namespace RRelationnelle.Modèles
{
    public class Category
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private Admin _creator { get; set; }

        public Category(int id, Admin creator, string name)
        {
            _id = id;
            _name = name;
            _creator = creator;

        }

       // public string Name { get { return _name; } set { _name = value; } }



    }
}
