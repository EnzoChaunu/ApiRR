using System;

namespace RRelationnelle.Modèles
{
    public class Comment
    {
        private int _id { get; set; }
        private Citizen _user { get; set; }
        private Ressource _ressource { get; set; }
        private string _content { get; set; }
        private int _likes { get; set; }
        private int _dislikes { get; set; }
        private bool _activation { get; set; }
        private bool _modified { get; set; }
        private DateTime _creationDate { get; set; }
        private DateTime _modificationDate { get; set; }

        public Comment(int id, Citizen user, Ressource ressource, string content, int likes, int dislikes, bool activation, bool modified, DateTime creationDate, DateTime modificationDate)
        {
            _id = id;
            _user = user;
            _ressource = ressource;
            _content = content;
            _likes = likes;
            _dislikes = dislikes;
            _activation = activation;
            _modified = modified;
            _creationDate = creationDate;
            _modificationDate = modificationDate;
        }

        public string Content { get { return _content; } set { _content = value; } }

        public int Id { get { return _id; } set { _id = value; } }

    }
}
