using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class MobileCoverDto : AccessoryDto
    {
        public double Size { get; set; }
        public string Material { get; set; }
        public string SpecialFeature { get; set; }
        public bool ForMobile { get; set; }
    }
}
