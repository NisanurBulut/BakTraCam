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
        public IEnumerable<BakimciEntity> Gerceklestirenler { get; set; }
        public IEnumerable<BakimciEntity> Sorumlular { get; set; }
        public int Oncelik { get; set; }
    }
}
