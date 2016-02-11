namespace BulBike.Services.Contracts
{
    using Models;
    using System;
    using System.Linq;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetById(String id);

        IQueryable<User> GetByUsername(string username);

        void UpdateUser(User updatedUser);
    }
}
