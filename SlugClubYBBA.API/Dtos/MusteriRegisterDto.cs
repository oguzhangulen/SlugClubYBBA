using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlugClubYBBA.API.Dtos
{
    public class MusteriRegisterDto
    {
        public string TCKN { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string Adres { get; set; }
        public string TelNo { get; set; }
        public string EPosta { get; set; }
    }
}
