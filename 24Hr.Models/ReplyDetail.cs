using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class ReplyDetail
    {
        public int ReplyId { get; set; }
        public string CommentText { get; set; }
        public int CommentId { get; set; }
        public string ReplyText { get; set; }
    }
}
