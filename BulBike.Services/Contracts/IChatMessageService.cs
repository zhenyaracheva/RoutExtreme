using BulBike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulBike.Services.Contracts
{
    public interface IChatMessageService
    {
        IQueryable<ChatMessage> GetAll();

        ChatMessage GetById(int id);

        void Create(ChatMessage message);
    }
}
