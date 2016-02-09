namespace BulBike.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ChatRoom
    {
        private ICollection<ChatMessage> messages;
        private ICollection<User> users;

        public ChatRoom()
        {
            this.messages = new HashSet<ChatMessage>();
        }

        [Key]
        public int Id { get; set; }

        public string ConnectionId { get; set; }

        public virtual ICollection<ChatMessage> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
