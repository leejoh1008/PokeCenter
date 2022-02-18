using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PokeCenter.Models
{
    public class PGameEdit
    {
       
        public int PGameId { get; set; }
        [Required]
        [Display(Name = "Name of Game:")]
        public string GameName { get; set; }
        [Required]
        public string Console { get; set; }
        [Required]
        [Display(Name = "Price:")]
        public double GamePrice { get; set; }
        [AllowHtml]
        [Required]
        [Display(Name = "Case?:")]
        public bool HasCase { get; set; }
        public byte[] FileContent { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
