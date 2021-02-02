using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class CommodityDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public CommodityType Type { get; set; }
        public string Remaining { get; set; }
        public int SalesNumber { get; set; }
        public string Brand { get; set; }
        public bool ImmediateSending { get; set; }
        public string AttachmentImageSource { get; set; }
        public Guid? AttachmentImageId { get; set; }
        public Guid? SelectedPromotionId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public AttachmentFileDto AttachmentFile { get; set; }
        public ICollection<PromotionDto> Promotions { get; set; }

    }
}
