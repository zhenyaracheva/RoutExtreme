namespace RouteExtreme.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Image : IDeletableEntity, IAuditInfo
    {
        public Image()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        [Required]
        [StringLength(10)]
        public string FileExtension { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
