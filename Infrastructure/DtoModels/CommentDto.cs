using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class CommentDto
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public Guid? CommodityId { get; set; }
        public string Title { get; set; }
        public string Advantages { get; set; }
        public string DisAdvantages { get; set; }
        public bool HasContent { get; set; }
        public string Content { get; set; }
        public bool SuggestToFriends { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
