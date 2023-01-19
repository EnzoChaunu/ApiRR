

using System;
// commmm
namespace RessourcesRelationelles.Class
{
    public class Comments
    {
        public int _id;
        public User _user;
        public Ressource _ressource;
        public string _content;
        public int _likes;
        public int _dislikes;
        public bool _activation;
        public bool _modified;
        public DateTime _creationDate;
        public
            DateTime _modificationDate;

        public int Id { get { return _id; } }
        public string Content { get { return _content; } set { _content = value; } }


    }
}
