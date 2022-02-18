using PokeCenter.Data;
using PokeCenter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PokeCenter.Services
{
    public class PCardService
    {
        private readonly Guid _userID;

        public PCardService(Guid userID)
        {
            _userID = userID;
        }

        public bool UploadImageInDataBase(PCardCreate contentViewModel)
        {
            byte[] bytes = null;
            if (contentViewModel.File != null)
            {
                Stream fileStream = contentViewModel.File.InputStream;
                BinaryReader reader = new BinaryReader(fileStream);
                bytes = reader.ReadBytes((Int32)fileStream.Length);
            }

            var content = new PCard()
            {
                CardName = contentViewModel.CardName,
                CardGrade = contentViewModel.CardGrade,
                CardPrice = contentViewModel.CardPrice,
                IsHolo = contentViewModel.IsHolo,
                FileContent = bytes,
                File = contentViewModel.File

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.PokemonCards.Add(content);
                ctx.Configuration.AutoDetectChangesEnabled = true;
                return ctx.SaveChanges() == 1;

            }
        }
        public PCardDetail GetPCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonCards
                        .Single(e => e.PCardId == id && e.OwnerId == _userID);
                return
                    new PCardDetail
                    {
                        PCardId = entity.PCardId,
                        CardName = entity.CardName,
                        CardPrice = entity.CardPrice,
                        CardGrade = entity.CardGrade,
                        IsHolo = entity.IsHolo,
                        FileContent = entity.FileContent,
                        File = entity.File

                    };
            }
        }
        public bool UpdatePCard(PCardEdit model)
        {

            Stream fileStream = model.File.InputStream;
            BinaryReader reader = new BinaryReader(fileStream);
            var bytes = reader.ReadBytes((Int32)fileStream.Length);

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonCards
                        .Single(e => e.PCardId == model.PCardId && e.OwnerId == _userID);

                entity.PCardId = model.PCardId;
                entity.CardName = model.CardName;
                entity.CardPrice = model.CardPrice;
                entity.CardGrade = model.CardGrade;
                entity.File = model.File;
                entity.FileContent = bytes;
                entity.IsHolo = model.IsHolo;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePC(int PCardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonCards
                        .Single(e => e.PCardId == PCardId && e.OwnerId == _userID);

                ctx.PokemonCards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
