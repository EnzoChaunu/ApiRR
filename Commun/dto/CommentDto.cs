using System;

namespace RRelationnelle
{
    public class CommentDto
    {
        private int _id { get; set; }
        private User _user { get; set; }
        private Ressource _ressource { get; set; }
        private string _content { get; set; }
        private int _likes { get; set; }
        private int _dislikes { get; set; }
        private bool _activation { get; set; }
        private bool _modified { get; set; }
        private DateTime _creationDate { get; set; }
        private DateTime _modificationDate { get; set; }

        public string Content { get { return _content; } set { _content = value; } }

        public int Id { get { return _id; } set { _id = value; } }

    }
}
