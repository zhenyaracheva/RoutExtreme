namespace RouteExtreme.Services
{
    using System.Linq;
    using RouteExtreme.Data.Repositories;
    using RouteExtreme.Models;
    using RouteExtreme.Services.Contracts;

    public class ChatRoomService : IChatRoomService
    {
        private IRepository<ChatRoom> rooms;

        public ChatRoomService(IRepository<ChatRoom> rooms)
        {
            this.rooms = rooms;
        }

        public void Create(ChatRoom room)
        {
            this.rooms.Add(room);
            this.rooms.SaveChanges();
        }

        public IQueryable<ChatRoom> GetAll()
        {
            return this.rooms.All();
        }

        public void MarkAsDeleted(ChatRoom room)
        {
            this.rooms.MarkAsDeleted(room);
            this.rooms.SaveChanges();
        }

        public IQueryable<ChatRoom> RoomsByUsername(string username)
        {
            return this.rooms.All()
                             .Where(x => x.Users.Any(u => u.UserName == username));
        }

        public void Update(ChatRoom room)
        {
            this.rooms.Update(room);
            this.rooms.SaveChanges();
        }
    }
}
