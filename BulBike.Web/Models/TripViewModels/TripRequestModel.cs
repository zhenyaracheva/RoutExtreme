namespace BulBike.Web.Models.TripViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TripRequestModel
    {
        [Required]
        public string Route { get; set; }

        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [Required]
        [UIHint("DatePicker")]
        public DateTime StartDate { get; set; }

        [Required]
        [UIHint("SingleLineText")]
        [DisplayName("Start Point")]
        public string StartPoint { get; set; }
    }
}