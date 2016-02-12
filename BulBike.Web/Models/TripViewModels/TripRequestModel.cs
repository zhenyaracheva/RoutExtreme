namespace BulBike.Web.Models.TripViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TripRequestModel
    {
        [Required]
        public string Route { get; set; }

        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [UIHint("DatePicker")]
        public DateTime StartDate { get; set; }
    }
}