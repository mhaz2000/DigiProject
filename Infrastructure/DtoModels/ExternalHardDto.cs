using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class ExternalHardDto : AccessoryDto
    {
        public string ConnectionType { get; set; }
        public string StirageType { get; set; }
        public bool WaterResistance { get; set; }
        public bool ImpactResistance { get; set; }
    }
}
