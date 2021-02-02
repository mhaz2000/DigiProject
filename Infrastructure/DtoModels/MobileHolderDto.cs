using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class MobileHolderDto : AccessoryDto
    {
        public bool Rotate360 { get; set; }
        public bool WirelessCharging { get; set; }
        public bool Rechargeable { get; set; }
    }
}
