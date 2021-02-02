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
    public class Promotion
    {
        public Promotion()
        {
            ID = Guid.NewGuid();
            CreatedTime = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public int Percent { get; set; }
        public string Type { get; set; }
        public PromotionStatus Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual Commodity Commodity { get; set; }
        [ForeignKey("Commodity")]
        public Guid? CommodityId { get; set; }
    }
}
