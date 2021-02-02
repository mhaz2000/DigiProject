using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Commodity
    {
        public Commodity()
        {
            ID = Guid.NewGuid();
            CreatedTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public CommodityType Type { get; set; }
        public string Remaining { get; set; }
        public int SalesNumber  { get; set; }
        public string Brand  { get; set; }
        [ForeignKey("AttachmentFile")]
        public Guid? AttachmentImageId { get; set; }
        public bool ImmediateSending  { get; set; }
        public string Description  { get; set; }
        public DateTime CreatedTime  { get; set; }
        //public virtual ICollection<Promotion> Promotions { get; set; }
        public Guid? PromotionId { get; set; }

        public AttachmentFile AttachmentFile { get; set; }
    }
}
