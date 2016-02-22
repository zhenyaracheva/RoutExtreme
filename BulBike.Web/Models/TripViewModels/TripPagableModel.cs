namespace BulBike.Web.Models.TripViewModels
{
    using Comments;
    using System.Collections.Generic;

    public class TripPagableModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IList<TripResponseModel> AllTrips { get; set; }
    }
}