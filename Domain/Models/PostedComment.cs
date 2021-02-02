using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PostedComment
    {
        public PostedComment()
        {
            ID = Guid.NewGuid();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public Guid PersonID { get; set; }
        public Guid CommentID { get; set; }
        public virtual Person Person { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
