using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class RessourceDto
    {
        public int _id { get; set; }

        public string reference { get; set; }
        public string _title { get; set; }
        public int Id_Category { get; set; }
        public bool _activation { get; set; }
        public User modification { get; set; }
        public int _user { get; set; }
        public int _views { get; set; }
        public int shared { get; set; }
        public DateTime _creationDate { get; set; }
        public string _url { get; set; }
        public List<CommentDto> _comments { get; set; }

        public RessourceDto(string title, int categoryId, string _reference, string url, int userId,int id)
        {
           
            _title = title;
            Id_Category = categoryId;
            reference = _reference;
            _url = url;
            _user = userId;
            _id = id;
            
        }

        public RessourceDto()
        {

        }
    }
}
