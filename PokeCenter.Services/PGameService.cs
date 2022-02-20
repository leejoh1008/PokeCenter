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
using System.Drawing;

namespace PokeCenter.Services
{
    public class PGameService
    {
        private readonly Guid _userID;

        public PGameService(Guid userID)
        {
            _userID = userID;
        }

        public bool UploadImageInDataBase(PGameCreate contentViewModel)
        {
            byte[] bytes = null;
            if (contentViewModel.File != null)
            {
                Stream fileStream = contentViewModel.File.InputStream;
                BinaryReader reader = new BinaryReader(fileStream);
                bytes = reader.ReadBytes((Int32)fileStream.Length);
            }

            var content = new PGame()
            {
                OwnerId = _userID,
                GameName = contentViewModel.GameName,
                GamePrice = contentViewModel.GamePrice,
                Console = contentViewModel.Console,
                HasCase = contentViewModel.HasCase,
                FileContent = bytes,
                File = contentViewModel.File

            };

            using (var ctx = new ApplicationDbContext())
            {
                
                ctx.PokemonGames.Add(content);
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
                        HasCase = entity.HasCase,
                        Console = entity.Console,
                        FileContent = entity.FileContent,
                        File = entity.File
                    };
            }
        }
        public IEnumerable<PGameListItem> GetAllPGame()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queury =
                    ctx
                        .PokemonGames
                        .Where(e => e.OwnerId == _userID)
                        .Select(entity => new PGameListItem
                        {
                            PGameId = entity.PGameId,
                            GameName = entity.GameName,
                            GamePrice = entity.GamePrice,
                            HasCase = entity.HasCase,
                            Console = entity.Console,
                            FileContent = entity.FileContent
                            
                        });
                return queury.ToArray();


            }
        }
        public bool EditPGame(PGameEdit model)
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
                entity.HasCase = model.HasCase;
                entity.Console = model.Console;

                return ctx.SaveChanges() == 1;
            }
        }
       /* public bool UpdatePGame(PGameEdit model)
        {
            Stream fileStream = model.File.InputStream;
            BinaryReader reader = new BinaryReader(fileStream);
            var bytes = reader.ReadBytes((Int32)fileStream.Length);
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonGames
                        .Single(e => e.PGameId == model.PGameId && e.OwnerId == _userID);

                entity.PGameId = model.PGameId;
                entity.GameName = model.GameName;
                entity.GamePrice = model.GamePrice;

                entity.HasCase = model.HasCase;
                entity.Console = model.Console;

                return ctx.SaveChanges() == 1;
            }
        }*/
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
        
       /* public HttpPostedFile PostedImage(int Id)
        {
            byte[] bytes = GettingImage(Id);
            if (bytes != null)
            {
                HttpPostedFile File = (HttpPostedFile)new MemoryPostedFile(bytes);
                /*Stream fileStream = contentViewModel.File.InputStream;
                Stream fileStream = contentViewModel.File.InputStream;
                BinaryReader reader = new BinaryReader(fileStream);
                bytes = reader.ReadBytes((Int32)fileStream.Length);*/

        
            
        
    }
}
