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
                    Content = model.Content,
                    Created = DateTimeOffset.Now
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
                                    Content = e.Content,
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
                        .Single(e => e.MessageId == id && e.OwnerId == _userID);
                return
                    new MessageDetail
                    {
                        MessageId = entity.MessageId,
                        Content = entity.Content,
                        Created = entity.Created,
                    };
            }
        }

       /* public bool UpdateNote(Mess model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteID == model.NoteID && e.OwnerID == _userID);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }*/

        public bool DeleteMessage(int MessageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == MessageId && e.OwnerId == _userID);

                ctx.Messages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
