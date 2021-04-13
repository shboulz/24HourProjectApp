using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class CommentCreate
    {
       [Required]
       [MinLength(1, ErrorMessage = "cannot be empty. Please enter atleast 1 character")]
       [MaxLength(2000, ErrorMessage = "cannot exceed 2000 characters.")]
        public string CommentText { get; set; }
        public Guid AuthorId { get; set; }

    }
}
