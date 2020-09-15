using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Common.Helper.Enums
{
    public partial class Enums
    {
        public enum BakimDurum
        {
            Beklemede = 1,
            Tamamlandi = 2,
            Iptal = 3,
            Devam = 4
        }
        public enum BakimTip
        {
            Planli = 1,
            Talep = 2,
            Ariza = 3,
            Periyodik = 4
        }
        public enum BakimPeriod
        {
            Gun = 1,
            BirHafta = 2,
            IkiHafta = 3,
            UcHafta = 4,
            BirAy = 5,
            IkiAy = 6,
            UcAy = 7,
            AltiAy = 8,
            BirSene = 9
        }
        public enum Unvan
        {
            Sorumlu = 1,
            BakimElemani = 2
        }
    }
}
