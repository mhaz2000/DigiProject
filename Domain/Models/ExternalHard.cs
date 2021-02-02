using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ExternalHard : ComputersAndAccessory
    {
        public ExternalHard()
        {

        }
        public string ConnectionType { get; set; }
        public string StirageType { get; set; }
        public bool WaterResistance { get; set; }
        public bool ImpactResistance { get; set; }
    }
}
