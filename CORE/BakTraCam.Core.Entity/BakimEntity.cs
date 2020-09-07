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
        public string Gerceklestiren1 { get; set; }
        public string Gerceklestiren2 { get; set; }
        public string Gerceklestiren3 { get; set; }
        public string Gerceklestiren4 { get; set; }
        public string Sorumlu1 { get; set; }
        public string Sorumlu2 { get; set; }
        public int Oncelik { get; set; }
    }
}
