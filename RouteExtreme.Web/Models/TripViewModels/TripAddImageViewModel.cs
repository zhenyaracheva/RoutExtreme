namespace RouteExtreme.Web.Models.TripViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class TripAddImageViewModel
    {
        [UIHint("SingleLineText")]
        public int TripID { get; set; }

        public IEnumerable<HttpPostedFileBase> Images { get; set; }
    }
}