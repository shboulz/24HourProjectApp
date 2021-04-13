﻿using _24HR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }

        public string Text { get; set; }
        public Guid AuthorId { get; set; }

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
