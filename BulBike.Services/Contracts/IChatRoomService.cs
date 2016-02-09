namespace BulBike.Services.Contracts
{
    using BulBike.Models;
    using System.Linq;

    public interface IChatRoomService
    {
        IQueryable<ChatRoom> GetAll();

        ChatRoom GetById(int id);

        void Create(ChatRoom room);
    }
}
