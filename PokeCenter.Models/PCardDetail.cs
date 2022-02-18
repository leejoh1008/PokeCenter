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
    public class PCardDetail
    {
        [Required]
        public int PCardId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public int CardGrade { get; set; }
        [Required]
        public double CardPrice { get; set; }
        [Required]
        public bool IsHolo { get; set; }
        public byte[] FileContent { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
