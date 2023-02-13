using System.Collections.Generic;
using System;

namespace RRelationnelle.Modèles
{
    public class Citizen : UserDto
    {
        private List<Ressource> _favRessources { get; set; }
        private List<Comment> _comments { get; set; }

        public Citizen(int id, string fName, string lName, string email, string password, string login, bool activation, DateTime creationDate, List<Ressource> favRessources, List<Comment> comments) : base(id, fName, lName, email, password, login, activation, creationDate)
        {
            _favRessources = favRessources;
            _comments = comments;
        }

        public void UpdateAccount()
        {

        }

        public void PostComment()
        {

        }

        public void ModifyComment(Comment comment, string content)
        {

            foreach (Comment c in _comments)
            {
                if (c.Id == comment.Id)
                    c.Content = content;
            }
        }



        public void AddFavRessource(Ressource res)
        {
            _favRessources.Add(res);
        }



    }
}
