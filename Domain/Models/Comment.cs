using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment
    {
        public Comment()
        {
            ID = Guid.NewGuid();
            SubmissionDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public Guid? CommodityId { get; set; }
        public string Title { get; set; }
        public string Advantages { get; set; }
        public string DisAdvantages { get; set; }
        public string Name { get; set; }
        public bool HasContent { get; set; }
        public string Content { get; set; }
        public bool SuggestToFriends { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual ICollection<PostedComment> PostedComments { get; set; }

    }
}
