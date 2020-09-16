using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Service.DataContract
{
    public class BakimModelBasic
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string Ad { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Gerceklestiren1 { get; set; }
        public string Gerceklestiren2 { get; set; }
        public string Gerceklestiren3 { get; set; }
        public string Gerceklestiren4 { get; set; }
        public string Sorumlu1 { get; set; }
        public string Sorumlu2 { get; set; }
        public int Period { get; set; }
        public int Durum { get; set; }
        public int Tip { get; set; }
    }
}
