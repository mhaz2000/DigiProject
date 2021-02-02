using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class PromotionDto
    {
        public Guid ID { get; set; }
        public int Percent { get; set; }
        public string Type { get; set; }
        public PromotionStatus Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public CommodityDto Commodity { get; set; }
    }
}
