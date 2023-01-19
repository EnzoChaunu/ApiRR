using System;
using System.Collections.Generic;

namespace RessourcesRelationelles.Class
{
    public class Citizen : User
    {
        private int _id;
        private string _fName;
        private string _lName;
        private string _email;
        private string _password;
        private string _login;
        private bool _activation;
        private DateTime _creationDate;
        private List<Ressource> _favRessources = new List<Ressource>();
        private List<Comments> _comments = new List<Comments>();

        public void UpdateAccount() 
        { 
            
        }

        public void PostComment()
        {

        }

        public void ModifyComment(Comments comment, string content) 
        {

            foreach (Comments c in _comments)
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
