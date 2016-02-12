namespace BulBike.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        [Key]
        public int Id { get; set; }
        
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
