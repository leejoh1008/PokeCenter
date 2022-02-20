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
    public class PGameListItem
    {
        
        public int PGameId { get; set; }
        
        public string GameName { get; set; }
        
        public string Console { get; set; }
       
        public double GamePrice { get; set; }
        
        public bool HasCase { get; set; }

        public byte[] FileContent { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
