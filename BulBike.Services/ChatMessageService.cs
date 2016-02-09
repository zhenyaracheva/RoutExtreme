namespace BulBike.Services
{
    using System;
    using System.Linq;
    using Models;
    using BulBike.Services.Contracts;
    using Data.Repositories;

    public class ChatMessageService : IChatMessageService
    {
        private IRepository<ChatMessage> messages;


        public ChatMessageService(IRepository<ChatMessage> messages)
        {
            this.messages = messages;
        }

        public void Create(ChatMessage message)
        {
            this.messages.Add(message);
            this.messages.SaveChanges();
        }

        public IQueryable<ChatMessage> GetAll()
        {
            return this.messages.All();
        }

        public ChatMessage GetById(int id)
        {
            return this.messages.All()
                               .Where(x => x.Id == id)
                               .FirstOrDefault();
        }
    }
}
