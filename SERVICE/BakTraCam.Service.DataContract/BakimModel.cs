using System;

namespace BakTraCam.Service.DataContract
{
    public class BakimModel
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string Ad { get; set; }
        public DateTime Tarihi { get; set; }
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
