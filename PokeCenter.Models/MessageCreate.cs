using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Models
{
    public class MessageCreate
    {
        [Required]
        [MaxLength(8000)]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        
        public string Content { get; set; }
    }
}
