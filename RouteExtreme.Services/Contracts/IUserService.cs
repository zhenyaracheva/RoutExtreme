namespace RouteExtreme.Services.Contracts
{
    using Models;
    using System;
    using System.Linq;

    public interface IUserService
    {
        void Create(User user, string password);

        IQueryable<User> GetAll();

        IQueryable<User> GetById(String id);

        IQueryable<User> GetByUsername(string username);

        void UpdateUser(User updatedUser);

        void Delete(string id);

        void MarkAsDeleted(User user);
    }
}
