namespace BulBike.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ChatRoom
    {
        private ICollection<User> users;
        private ICollection<ChatMessage> messages;

        public ChatRoom()
        {
            this.users = new HashSet<User>();
            this.messages = new HashSet<ChatMessage>();
        }
        
        public int Id { get; set; }
        
        public string ConnectionId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<ChatMessage> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
