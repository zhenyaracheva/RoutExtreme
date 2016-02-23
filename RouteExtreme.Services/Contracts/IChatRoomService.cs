namespace RouteExtreme.Services.Contracts
{
    using System.Linq;
    using RouteExtreme.Models;
    
    public interface IChatRoomService
    {
        IQueryable<ChatRoom> GetAll();
        
        void Create(ChatRoom room);
        
        IQueryable<ChatRoom> RoomsByUsername(string username);

        void Update(ChatRoom room);

        void MarkAsDeleted(ChatRoom user);
    }
}
