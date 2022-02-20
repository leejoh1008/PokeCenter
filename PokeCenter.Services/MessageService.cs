using PokeCenter.Data;
using PokeCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCenter.Services
{
    public class MessageService
    {
        private readonly Guid _userID;

        public MessageService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    OwnerId = _userID,
                    Title=model.Title,
                    Content = model.Content,
                    Email=model.Email,
                    Created = DateTimeOffset.Now,
                    Receiver = model.Receiver
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MessageListItem> GetMessages()
            {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.OwnerId == _userID)
                        .Select(
                            e =>
                                new MessageListItem
                                {
                                    MessageId = e.MessageId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    Email = e.Email,
                                    Created = e.Created
                                }
                        );

                return query.ToArray();

            }
        }
        // wait is this how I list items with the same receiver...
        public IEnumerable<MessageListItem> ReceiveMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.Receiver == _userID.ToString())
                        .Select(
                            e =>
                                new MessageListItem
                                {
                                    MessageId = e.MessageId,
                                    Title=e.Title,
                                    Content = e.Content,
                                    Email=e.Email,
                                    Created = e.Created
                                }
                        );

                return query.ToArray();

            }
        }

        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == id);
                return
                    new MessageDetail
                    {
                        MessageId = entity.MessageId,
                        Title = entity.Title,
                        Content = entity.Content,
                        Email=entity.Email,
                        Created = entity.Created,

                    };
            }
        }
        


        public bool DeleteMessage(int MessageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == MessageId );

                ctx.Messages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //trying to get user string id by getting the guid by the select cardid 
        //IMPORTANT: NEED TO SET MESSAGE.RECEIVER = GETPCARDUSER(GETPOKEMONCARDBYID);
        //this returns the owner guid id as a string of the selected card
        public string GetPCardUser(int PCardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .PokemonCards
                .Single(e => e.PCardId == PCardId);
                new PCard
                {
                    OwnerId = entity.OwnerId
                };


                string PCardUserId = entity.OwnerId.ToString();
                return PCardUserId;

            }
        }
        // GENIUS U FINALLY FIGURED IT OUT???? WE'LL SEE
        //this method below ideally should let me return any messages that have the same receiver string as my 
        //current logged in ownerId

        public MessageDetail GetMessageByString(int PCardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                string vs = GetPCardUser(PCardId);
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.OwnerId.ToString() == vs);
                return
                    new MessageDetail
                    {
                        MessageId = entity.MessageId,
                        Title = entity.Title,
                        Content = entity.Content,
                        Email=entity.Email,
                        Created = entity.Created//,
                        //Receiver = entity.Receiver
                    };
            }
        }
        //.where(e=> e.PcardUserId == OwnerId
        /* .Select(
        e =>
                                new MessageListItem
                                {
                                    MessageId = e.MessageId,
                                    Content = e.Content,
                                    Created = e.Created
    }
                        );

                return query.ToArray();*/
    }
}
