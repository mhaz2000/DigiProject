using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class MobileDto : CommodityDto
    {
        public int MobileRam { get; set; }
        public int InternalStorage { get; set; }
        public int CameraResolution { get; set; }
        public string OS { get; set; }
        public string Network { get; set; }
        public string Model { get; set; }
    }
}
