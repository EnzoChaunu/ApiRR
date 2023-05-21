using System;

namespace RRelationnelle
{
    public class StatsDto
    {
        public int _id { get; set; }
        public int _visits { get; set; }
        public int _accountsCreated { get; set; }
        public int _Shared { get; set; }
        public int _favorite { get; set; }
        public int _commentPosted { get; set; }
        public DateTime _createdAt { get; set; }
    }
}
