using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.Entity
{
    public class BakimEntity : BaseEntity
    {

        public string Aciklama { get; set; }
        public string Ad { get; set; }
        public DateTime Tarihi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int Gerceklestiren1 { get; set; }
        public int Gerceklestiren2 { get; set; }
        public int Gerceklestiren3 { get; set; }
        public int Gerceklestiren4 { get; set; }
        public int Sorumlu1 { get; set; }
        public int Sorumlu2 { get; set; }
        public int Period { get; set; }
        public int Durum { get; set; }
        public int Tip { get; set; }
    }
}
