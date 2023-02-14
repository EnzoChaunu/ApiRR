using System;
using System.ComponentModel.DataAnnotations;

namespace RRelationnelle
{
    public class Stats
    {
        [Key]
        public int id_stat { get; set; }
        public int NbSharing { get; set; }
        public int NbLike { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public DateTime DateStat { get; set; }





    }
}
