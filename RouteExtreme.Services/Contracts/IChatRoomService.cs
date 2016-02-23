namespace RouteExtreme.Services.Contracts
{
    using RouteExtreme.Models;
    using System.Linq;

    public interface IChatRoomService
    {
        IQueryable<ChatRoom> GetAll();

        //ChatRoom GetById(int id);

        void Create(ChatRoom room);

        //ChatRoom GetByConnectionId(string id);

        IQueryable<ChatRoom> RoomsByUsername(string username);

        void Update(ChatRoom room);

        void MarkAsDeleted(ChatRoom user);
    }
}
