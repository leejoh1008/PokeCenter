using PokeCenter.Data;
using PokeCenter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PokeCenter.Services
{
    public class PGameService
    {
        private readonly Guid _userID;

        public PGameService(Guid userID)
        {
            _userID = userID;
        }

        public bool UploadImageInDataBase(HttpPostedFileBase file, PGameCreate contentViewModel)
        {
            byte[] imageBytes = null;
            if(contentViewModel.GameFile != null)
            {
                Stream CardStream = contentViewModel.GameFile.InputStream;
                BinaryReader reader = new BinaryReader(CardStream);
                imageBytes = reader.ReadBytes((Int32)CardStream.Length);
             }

             var content = new PGame()
            {
                GameName = contentViewModel.GameName,
                GamePrice = contentViewModel.GamePrice,
                Console = contentViewModel.Console,
                HasCase= contentViewModel.HasCase,
                GameImage = imageBytes
                
            };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.PokemonGames.Add(content);
                ctx.Configuration.AutoDetectChangesEnabled = true;
                return ctx.SaveChanges() == 1;
                
            }
        }
        public PGameDetail GetPGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonGames
                        .Single(e => e.PGameId == id && e.OwnerId == _userID);
                return
                    new PGameDetail
                    {
                        PGameId = entity.PGameId,
                        GameName = entity.GameName,
                        GamePrice = entity.GamePrice,
                        GameImage = entity.GameImage,
                        HasCase = entity.HasCase,
                        Console = entity.Console
                    };
            }
        }
        public string GetGameName(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonGames
                        .Single(e => e.PGameId == id && e.OwnerId == _userID);
                new PGameDetail
                {
                    PGameId = entity.PGameId,
                    GameName = entity.GameName,
                    GamePrice = entity.GamePrice,
                    GameImage = entity.GameImage,
                    HasCase = entity.HasCase,
                    Console = entity.Console
                };
                string GameString = entity.GameName;
                return GameString;
                    }
                    
   
        }
        public bool UpdatePGame(PGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonGames
                        .Single(e => e.PGameId == model.PGameId && e.OwnerId == _userID);

                entity.PGameId = model.PGameId;
                entity.GameName = model.GameName;
                entity.GamePrice = model.GamePrice;
                entity.GameImage = model.GameImage;
                entity.HasCase = model.HasCase;
                entity.Console = model.Console;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePG(int PGameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonGames
                        .Single(e => e.PGameId == PGameId && e.OwnerId == _userID);

                ctx.PokemonGames.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
