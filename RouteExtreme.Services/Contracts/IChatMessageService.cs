namespace RouteExtreme.Services.Contracts
{
    using System.Linq;
    using RouteExtreme.Models;

    public interface IChatMessageService
    {
        IQueryable<ChatMessage> GetAll();

        ChatMessage GetById(int id);

        void Create(ChatMessage message);
    }
}
