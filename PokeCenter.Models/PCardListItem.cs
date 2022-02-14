using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Models
{
    public class PCardListItem
    {
        public int PCardId { get; set; }
        public string CardName { get; set; }
        public int CardGrade { get; set; }
        public double CardPrice { get; set; }
        public bool IsHolo { get; set; }
    }
}
