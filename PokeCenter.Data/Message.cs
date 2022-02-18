using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please include a title!")]
        public string Title { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please type to message this person!")]
        [MaxLength(200, ErrorMessage = "You have written too much please reduce text!")]
        public string Content { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please leave a gmail to repond to!")]
        public string Email { get; set; }
        [Required]
        [ForeignKey("User")]
        public string Receiver { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; } 
    }
}
