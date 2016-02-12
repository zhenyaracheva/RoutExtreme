namespace BulBike.Web.Models.TripViewModels
{
    using System;
    using BulBike.Models;
    using System.ComponentModel.DataAnnotations;

    public class TripRequestModel
    {
        [Required]
        public string Route { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
    }
}