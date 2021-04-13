using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class ReplyCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Cannot be empty. Please enter atleast one character")]
        [MaxLength(2000, ErrorMessage = "Cannot exceed 2000 characters.")]
        public string ReplyText { get; set; }

        public int CommentId { get; set; }

    }
}
