

using System;

namespace RessourcesRelationelles.Class
{
    public class Comments
    {
        private int _id;
        private User _user;
        private Ressource _ressource;
        private string _content;
        private int _likes;
        private int _dislikes;
        private bool _activation;
        private bool _modified;
        private DateTime _creationDate;
        private DateTime _modificationDate;

        public int Id { get { return _id; } }
        public string Content { get { return _content; } set { _content = value; } }


    }
}
