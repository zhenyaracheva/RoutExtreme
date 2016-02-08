namespace BulBike.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LocationViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}