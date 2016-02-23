namespace RouteExtreme.Web.Models
{
    using System.Collections.Generic;

    public class PagableViewModel<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IList<T> All { get; set; }
    }
}