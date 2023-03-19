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
        public User _modification { get; set; }
        public int _views { get; set; }
        public DateTime _creationDate { get; set; }
        public string _url { get; set; }
        public List<CommentDto> _comments { get; set; }
    }
}
