using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SlugClubYBBA.API.Models
{
    public class Hesap
    {
        [Key]
        [Column(Order =0)]
        public string HesapNo { get; set; }
        [Key]
        [Column(Order = 1)]
        public int EkNo { get; set; }
        public decimal BakiyeBilgi { get; set; }
        public bool AktiflikDurumu { get; set; }
        [ForeignKey("Musteri")]
        public string TCKN { get; set; }
        public Musteri Musteri { get; set; }

    }
}
