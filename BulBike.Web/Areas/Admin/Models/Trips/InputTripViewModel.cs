namespace BulBike.Web.Areas.Admin.Models.Trips
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class InputTripViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        [UIHint("MultiLineText")]
        public string Description { get; set; }
        
        [UIHint("DatePicker")]
        public DateTime StartDate { get; set; }
        
        [UIHint("SingleLineText")]
        [DisplayName("Start Point")]
        public string StartPoint { get; set; }
    }
}