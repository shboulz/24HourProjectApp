using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HR.Data
{
    public class Reply
    {
        [Key]
        public int ReplyID { get; set; }

        [Required]
        public string ReplyText { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentID { get; set; }

        [Required]
        public Guid AuthorID { get; set; }

    }
}
