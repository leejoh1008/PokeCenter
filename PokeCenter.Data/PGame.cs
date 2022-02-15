﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PokeCenter.Data
{
    public class PGame
    {
        [Key]
        public int PGameId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public string Console { get; set; }
        [Required]
        public double GamePrice { get; set; }
        [Required]
        public bool HasCase { get; set; }
        [Required]
         public byte[] GameImage { get; set; }
    }
}
