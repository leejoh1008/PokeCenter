using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Models
{
    public class PGameCreate
    {
        [Required]
        [Display(Name = "Name of Game:")]
        public string GameName { get; set; }
        [Required]
        public string Console { get; set; }
        [Required]
        [Display(Name = "Price:")]
        public double GamePrice { get; set; }
        [Required]
        [Display(Name = "Case?: y or n")]
        public bool HasCase { get; set; }
        [Required]
        public byte[] GameImage { get; set; }

    }
}
