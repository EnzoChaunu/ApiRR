using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RRelationnelle
{
    public class Stats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_stat { get; set; }

        [Column]
        public int AcountCreated { get; set; }
        public int commentposted { get; set; }
        public int visits { get; set; }
        public DateTime DateStat { get; set; }
    }
}
