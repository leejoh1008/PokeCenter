using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PokeCenter.Models
{
    public class PCardCreate
    {
        [Required]
        [Display(Name ="Pokemon:")]
        public string CardName { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Please enter a grade between 1 to 10.")]
        [Display(Name ="Grade:")]
        public int CardGrade { get; set; }
        [Required]
        [Display(Name = "Price:")]
        public double CardPrice { get; set; }
        [Required]
        [Display(Name = "Holo?:")]
        public bool IsHolo { get; set; }
        public byte[] FileContent { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
