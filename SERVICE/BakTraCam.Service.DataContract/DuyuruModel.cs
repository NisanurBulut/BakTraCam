using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Service.DataContract
{
    public class DuyuruModel
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarihi { get; set; }
    }
}
