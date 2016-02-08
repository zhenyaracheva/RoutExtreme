namespace BulBike.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        private ICollection<Trip> trips;

        public Location()
        {
            this.trips = new HashSet<Trip>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public virtual ICollection<Trip> Trips
        {
            get { return this.trips; }
            set { this.trips = value; }
        }
    }
}
