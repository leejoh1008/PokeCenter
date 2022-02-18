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
        [MinLength(1, ErrorMessage = "Please include a title!")]
        public string Title { get; set; }
        [Required]
        [MaxLength(8000)]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        
        public string Content { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please leave a gmail to repond to!")]
        public string Email { get; set; }
        public string Receiver { get; set; }

    }
}
