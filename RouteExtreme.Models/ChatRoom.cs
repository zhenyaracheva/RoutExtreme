namespace RouteExtreme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ChatRoom : IDeletableEntity, IAuditInfo
    {
        private ICollection<User> users;
        private ICollection<ChatMessage> messages;

        public ChatRoom()
        {
            this.users = new HashSet<User>();
            this.messages = new HashSet<ChatMessage>();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string ConnectionId { get; set; }

        [Index(IsUnique =true)]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

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
