using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class RessourceDto
    {
        public int _id { get; set; }

        public string reference { get; set; }
        public string _title { get; set; }
        public int idCateg { get; set; }
        public CategoryDto _category { get; set; }
        public int Idcategory { get; set; }
        public bool _activation { get; set; }
        public User _modification { get; set; }
        public int _user { get; set; }
        public int _views { get; set; }
        public DateTime _creationDate { get; set; }
        public string _url { get; set; }
        public List<CommentDto> _comments { get; set; }

        public RessourceDto(string title, int categoryId, string _reference, string url, int userId)
        {
           
            _title = title;
            idCateg = categoryId;
            reference = _reference;
            _url = url;
            _user = userId;
            
        }

        public RessourceDto()
        {

        }
    }
}
