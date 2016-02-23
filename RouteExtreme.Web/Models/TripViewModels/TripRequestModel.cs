namespace RouteExtreme.Web.Models.TripViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TripRequestModel
    {
        [Required]
        public string Route { get; set; }

        [UIHint("MultiLineText")]
        [StringLength(20000)]
        public string Description { get; set; }

        [Required]
        [UIHint("DatePicker")]
        public DateTime StartDate { get; set; }

        [Required]
        [UIHint("SingleLineText")]
        [DisplayName("Start Point")]
        [StringLength(200)]
        public string StartPoint { get; set; }

        [Required]
        [UIHint("SingleLineText")]
        [DisplayName("Chat Room Name")]
        [StringLength(20)]
        public string ChatRoomName { get; set; }
    }
}