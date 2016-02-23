namespace RouteExtreme.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Location : IDeletableEntity, IAuditInfo
    {
        public Location()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
