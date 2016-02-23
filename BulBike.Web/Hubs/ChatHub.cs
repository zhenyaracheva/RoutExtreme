namespace BulBike.Web.Hubs
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using BulBike.Models;
    using Data;
    using Microsoft.AspNet.SignalR;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    [Authorize]
    public class ChatHub : Hub
    {
        private const int LastMessages = 50;

        public override Task OnConnected()
        {
            using (var db = new BulBikeDbContext())
            {
                var user = db.Users
                    .Include(u => u.ChatRooms)
                    .SingleOrDefault(u => u.UserName == Context.User.Identity.Name);

                foreach (var item in user.ChatRooms)
                {
                    Groups.Add(Context.ConnectionId, item.Name);
                }

                var rooms = user.ChatRooms
                                    .Select(x => new
                                    {
                                        ConnectionId = x.ConnectionId,
                                        Name = x.Name
                                    })
                                    .ToList();

                var roomsAsJson = JsonConvert.SerializeObject(rooms);
                Clients.Caller.onConnected(roomsAsJson);
            }
            return base.OnConnected();
        }

        public void AddToRoom(string roomName)
        {
            using (var db = new BulBikeDbContext())
            {
                var user = db.Users
                    .Include(u => u.ChatRooms)
                    .SingleOrDefault(u => u.UserName == Context.User.Identity.Name);

                var room = db.ChatRooms.FirstOrDefault(x => x.Name == roomName);

                if (room != null)
                {
                    db.Users.Attach(user);
                    room.Users.Add(user);

                }
                else
                {
                    var newRoom = new ChatRoom
                    {
                        Name = roomName,
                        ConnectionId = Context.ConnectionId
                    };

                    newRoom.Users.Add(user);
                    db.ChatRooms.Add(newRoom);
                }

                db.SaveChanges();
                Groups.Add(Context.ConnectionId, roomName);
            }
        }

        public void RemoveFromRoom(string roomName)
        {
            using (var db = new BulBikeDbContext())
            {
                var room = db.ChatRooms.FirstOrDefault(x => x.Name == roomName);
                var user = db.Users
                   .Include(u => u.ChatRooms)
                   .SingleOrDefault(u => u.UserName == Context.User.Identity.Name);

                if (room != null)
                {
                    db.Users.Attach(user);
                    room.Users.Remove(user);
                    db.SaveChanges();

                    if (room.Users.Count == 0)
                    {
                        Groups.Remove(Context.ConnectionId, roomName);
                    }
                }
            }
        }

        public void SendMessage(string message, string room)
        {
            using (var db = new BulBikeDbContext())
            {
                var currentRoom = db.ChatRooms
                                              .Where(x => x.Name == room)
                                              .FirstOrDefault();

                var user = currentRoom.Users
                                            .FirstOrDefault(x => x.UserName == this.Context.User.Identity.Name);

                var msg = new ChatMessage
                {
                    AuthorId = user.Id,
                    Message = message.Trim()
                };

                currentRoom.Messages.Add(msg);
                db.SaveChanges();

                Clients.Group(room).SendPrivateMessage(currentRoom.ConnectionId, Context.User.Identity.Name, message);
            }
        }
        
        public void GetRoomMessages(string roomName)
        {
            using (var db = new BulBikeDbContext())
            {
                var room = db.ChatRooms
                                       .Where(x => x.Name == roomName)
                                       .FirstOrDefault();
                if (room != null)
                {
                    var allMessages = room.Messages.Count;
                    var itemsToSkip = allMessages - LastMessages;
                    var messages = room.Messages
                                                .OrderBy(x => x.CreatedOn)
                                                .Skip(itemsToSkip)
                                                .Take(LastMessages)
                                                .Select(x => new
                                                {
                                                   username= x.Author.UserName,
                                                   createdOn = x.CreatedOn,
                                                   message = x.Message
                                                })
                                                .ToList();
                    
                    for (int i = 0; i < messages.Count; i++)
                    {
                        var message = messages[i];
                        Clients.Group(roomName).SendPrivateMessage(room.ConnectionId,message.username, message.message);
                    }
                }
            }
        }
    }
}