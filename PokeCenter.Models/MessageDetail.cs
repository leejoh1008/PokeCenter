﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Models
{
    public class MessageDetail
    {
        [Required]
        public int MessageId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Receiver { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset Created { get; set; }

    }
}
