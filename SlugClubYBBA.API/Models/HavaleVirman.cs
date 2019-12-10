using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SlugClubYBBA.API.Models
{
    public class HavaleVirman
    {
        public int Id { get; set; }
        [Column(Order = 0)]
        public string GonderenHesapNo { get; set; }
        [Column(Order = 1)]

        public int GonderenHesapEkno { get; set; }
        [Column(Order = 2)]
        public string AliciHesapNo { get; set; }

        [Column(Order = 3)]

        public int AliciHesapEkno { get; set; }
        [ForeignKey("GonderenHesapNo,GonderenHesapEkno")]
        public virtual Hesap GonderenHesap { get; set; }
        [ForeignKey("AliciHesapNo,AliciHesapEkno")]
        public virtual Hesap AliciHesap { get; set; }
        public decimal Miktar { get; set; }
        public DateTime Time { get; set; }
        public string Tur { get; set; }
    }
}
