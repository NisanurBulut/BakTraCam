using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BakTraCam.Service.DataContract
{
    public class SelectModel
    {
        public string KeyStr
        {
            get
            {
                return Key.ToString();
            }
            set
            {
                if (int.TryParse(value, out int valInt))
                    Key = valInt;
                else if (decimal.TryParse(value, out decimal valDec))
                    Key = valDec;
                else
                    Key = value;
            }
        }

        [NotMapped]
        public object Key { get; set; }
        public string Name { get; set; }
    }
}
