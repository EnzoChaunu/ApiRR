using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class CitizenDto : UserDto
    {
        private List<Ressource> _favRessources { get; set; }
        private List<CommentDto> _comments { get; set; }

        /*public Citizen(int id, string fName, string lName, string email, string password, string login, bool activation, DateTime creationDate, List<Ressource> favRessources, List<Comment> comments) : base(id, fName, lName, email, password, login, activation, creationDate)
        {
            _favRessources = favRessources;
            _comments = comments;
        }*/

        public void UpdateAccount()
        {

        }

        public void PostComment()
        {

        }

        public void ModifyComment(CommentDto comment, string content)
        {

            foreach (CommentDto c in _comments)
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
