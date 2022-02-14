using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Models
{
    public class PCardCreate
    {
        [Required]
        public string CardName { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Please enter a grade between 1 to 10.")]
        public int CardGrade { get; set; }
        [Required]
        public double CardPrice { get; set; }
        [Required]
        public bool IsHolo { get; set; }
    }
}
