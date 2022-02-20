using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PokeCenter.Models
{
    public class PCardListItem
    {
        public int PCardId { get; set; }
        public string CardName { get; set; }
        public int CardGrade { get; set; }
        public double CardPrice { get; set; }
        public bool IsHolo { get; set; }
        public byte[] FileContent { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
