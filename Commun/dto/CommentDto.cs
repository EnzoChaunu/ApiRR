using System;

namespace RRelationnelle
{
    public class CommentDto
    {
        public int Id { get; private set; }
        public int UserId { get; set; }
        public int RessourceId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool Activation { get; set; }
        public bool Modified { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }


    }
}
