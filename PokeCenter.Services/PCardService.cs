using PokeCenter.Data;
using PokeCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Services
{
    public class PCardService
    {
    private readonly Guid _userId;
    public PCardService(Guid userId)
    {
        _userId = userId;
    }
        public bool CreatePCard(PCardCreate model)
        {
            var entity =
                new PCard()
                {
                    OwnerId = _userId,
                    CardName = model.CardName,
                    CardGrade = model.CardGrade,
                    CardPrice=model.CardPrice,
                    IsHolo = model.IsHolo
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PokemonCards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            
        }
        public IEnumerable<PCardListItem> GetPCards()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx.PokemonCards.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PCardListItem
                                {
                                    CardName=e.CardName,
                                    CardPrice=e.CardPrice,
                                    IsHolo =e.IsHolo
                                });
                    return query.ToArray();
                }
            }
    }
}
