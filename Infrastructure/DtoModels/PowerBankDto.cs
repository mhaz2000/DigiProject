using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class PowerBankDto : AccessoryDto
    {
        public double Flow { get; set; }
        public int Capacity { get; set; }
        public string WeightClass { get; set; }
        public string SpecialFeatures { get; set; }
        public int OutputNumbers { get; set; }
        public string BodyMaterial { get; set; }
        public ICollection<PromotionDto> Promotions { get; set; }
    }
}
