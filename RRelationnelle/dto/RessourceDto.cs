using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class RessourceDto
    {
        public int _id { get; set; }

        public string id { get; set; }
        public string title { get; set; }
        public CategoryDto _category { get; set; }
        public bool _activation { get; set; }
        public Admin _modification { get; set; }
        public int _views { get; set; }
        public DateTime _creationDate { get; set; }
        public string _url { get; set; }
        public List<CommentDto> _comments { get; set; }

      /*  public RessourceDto(string reference, string _title, CategoryDto category, bool activation, Admin modification, int views, DateTime creationDate, string url, List<CommentDto> comments)
        {
           
            title = _title;
            _category = category;
            _activation = activation;
            _modification = modification;
            _views = views;
            _creationDate = creationDate;
            _url = url;
            _comments = comments;
            id = reference;
        }


        public RessourceDto(string reference,string _title)
        {
            id = reference;
            title = _title;
            
        }*/
    }
}
