using BulBike.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulBike.Models;
using BulBike.Data.Repositories;

namespace BulBike.Services
{
    class ChatRoomService : IChatRoomService
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

        public ChatRoom GetById(int id)
        {
            return this.rooms.All()
                              .Where(x => x.Id == id)
                              .FirstOrDefault();
        }

        public ChatRoom GetByConnectionId(string id)
        {
            return this.rooms.All()
                              .Where(x => x.ConnectionId == id)
                              .FirstOrDefault();
        }
    }
}
