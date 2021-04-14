using _24HR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class CommentListItem
    {

        public int CommentId { get; set; }

        public string CommentText { get; set; }
        public int Id { get; set; }

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
