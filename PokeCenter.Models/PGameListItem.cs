using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Models
{
    public class PGameListItem
    {
        
        public int PGameId { get; set; }
        
        public string GameName { get; set; }
        
        public string Console { get; set; }
       
        public double GamePrice { get; set; }
        
        public bool HasCase { get; set; }
    }
}
