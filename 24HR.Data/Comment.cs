using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HR.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey(nameof(Post))]
        public int Id { get; set; }
        public virtual Post Post { get; set; }

        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public List<Reply> Replies { get; set; } = new List<Reply>();


    }
}
