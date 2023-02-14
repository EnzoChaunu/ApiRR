using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class RessourceDto
    {
        private int _id { get; set; }
        private string _title { get; set; }
        private string _description { get; set; }
        private string _content { get; set; }
        private CategoryDto _category { get; set; }
        private bool _activation { get; set; }
        private Admin _modification { get; set; }
        private int _views { get; set; }
        private DateTime _creationDate { get; set; }
        private string _url { get; set; }
        private List<CommentDto> _comments { get; set; }

        public RessourceDto(int id, string title, string description, string content, CategoryDto category, bool activation, Admin modification, int views, DateTime creationDate, string url, List<CommentDto> comments)
        {
            _id = id;
            _title = title;
            _description = description;
            _content = content;
            _category = category;
            _activation = activation;
            _modification = modification;
            _views = views;
            _creationDate = creationDate;
            _url = url;
            _comments = comments;
        }
    }
}
