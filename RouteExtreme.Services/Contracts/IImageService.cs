namespace RouteExtreme.Services.Contracts
{
    using System.Linq;
    using Models;
    
    public interface IImageService
    {
        IQueryable<Image> GetAll();

        Image GetById(int id);

        void Create(Image image);

        void MarkAsDeleted(Image image);
    }
}
