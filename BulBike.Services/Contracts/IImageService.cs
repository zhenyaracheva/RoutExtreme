namespace BulBike.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IImageService
    {
        IQueryable<Image> GetAll();

        Image GetById(int id);
        
        void Create(Image image);
    }
}
