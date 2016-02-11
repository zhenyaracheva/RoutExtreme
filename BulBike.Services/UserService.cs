namespace BulBike.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using Data.Repositories;
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class UserService : IUserService
    {
        private IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<User> GetById(String id)
        {
            return this.users
                        .All()
                        .Where(u => u.Id == id);
        }

        public IQueryable<User> GetByUsername(string username)
        {
            return this.users.All()
                .Where(x => x.UserName == username);

        }

        public void UpdateUser(User user)
        {
            this.users.Update(user);
            this.users.SaveChanges();
        }
    }
}
