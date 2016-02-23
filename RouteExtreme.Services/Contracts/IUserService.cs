namespace RouteExtreme.Services.Contracts
{
    using System.Linq;
    using Models;
    
    public interface IUserService
    {
        void Create(User user, string password);

        IQueryable<User> GetAll();

        IQueryable<User> GetById(string id);

        IQueryable<User> GetByUsername(string username);

        void UpdateUser(User updatedUser);

        void Delete(string id);

        void MarkAsDeleted(User user);
    }
}
