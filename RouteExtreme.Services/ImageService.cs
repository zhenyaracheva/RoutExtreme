namespace RouteExtreme.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class ImageService : IImageService
    {
        private IRepository<Image> images;
        
        public ImageService(IRepository<Image> images)
        {
            this.images = images;
        }

        public void Create(Image image)
        {
            this.images.Add(image);
            this.images.SaveChanges();
        }

        public IQueryable<Image> GetAll()
        {
            return this.images.All();
        }

        public Image GetById(int id)
        {
            return this.images.All()
                              .Where(x => x.Id == id)
                              .FirstOrDefault();
        }

        public void MarkAsDeleted(Image image)
        {
            this.images.MarkAsDeleted(image);
            this.images.SaveChanges();
        }
    }
}
