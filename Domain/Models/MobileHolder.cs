using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MobileHolder : Accessory
    {
        public MobileHolder()
        {

        }
        public bool Rotate360 { get; set; }
        public bool WirelessCharging { get; set; }
        public bool Rechargeable { get; set; }
    }
}
