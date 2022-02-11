using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int GamePrice { get; set; }
        [Required]
        public bool HasCase { get; set; }
    }
}
