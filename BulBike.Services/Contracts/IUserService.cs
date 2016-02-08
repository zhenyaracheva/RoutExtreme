namespace BulBike.Services
{
    using Models;
    using System;
    using System.Linq;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(String id);
    }
}
