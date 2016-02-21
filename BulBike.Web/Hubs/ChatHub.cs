namespace BulBike.Web.Hubs
{
    using BulBike.Models;
    using Data;
    using Microsoft.AspNet.SignalR;
    using Newtonsoft.Json;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    //using System.Web.Mvc;

    [Authorize]
    public class ChatHub : Hub
    {
        public override Task OnConnected()
        {
            using (var db = new BulBikeDbContext())
            {
                var user = db.Users
                    .Include(u => u.ChatRooms)
                    .SingleOrDefault(u => u.UserName == Context.User.Identity.Name);

                // Add to each assigned group.
                foreach (var item in user.ChatRooms)
                {
                    Groups.Add(Context.ConnectionId, item.Name);
                }

                var t = user.ChatRooms
                                    .Select(x => new
                                    {
                                        ConnectionId = x.ConnectionId,
                                        Name = x.Name
                                    })
                                    .ToList();

                var test = JsonConvert.SerializeObject(t);
                Clients.Caller.onConnected(test);
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
                    db.SaveChanges();
                    Groups.Add(Context.ConnectionId, roomName);
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
                    db.SaveChanges();
                    Groups.Add(Context.ConnectionId, roomName);
                }
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
                    //db.Users.Attach(user);
                    room.Users.Remove(user);
                    db.SaveChanges();
                    // Groups.Remove(Context.ConnectionId, roomName);
                }
            }
        }

        //public ActionResult GetRoomsByUser()
        //{
        //    using (var db = new BulBikeDbContext())
        //    {
        //        var rooms = db.ChatRooms
        //                        .Where(x => x.Users.Any(u => u.UserName == this.Context.User.Identity.Name))
        //                        .ToList();


        //    }
        //}

        public void SendMessage(string message, string room)
        {
            using (var db = new BulBikeDbContext())
            {
                var currentRoom = db.ChatRooms.Where(x => x.Name == room)
                                         .FirstOrDefault();

                Clients.Group(room).SendPrivateMessage(currentRoom.ConnectionId, Context.User.Identity.Name, message);
            }
        }
    }
}