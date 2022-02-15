using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Models
{
    public class MessageListItem
    {
        /*public int MessageId { get; set; }*/
        
        public string Content { get; set; }
        [Display(Name ="Message sent to:")]
        public string Receiver { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset Created { get; set; }
    }
}
