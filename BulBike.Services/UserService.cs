namespace BulBike.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using Data.Repositories;
    using System;
    using System.Collections.Generic;

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

        public User GetById(String id)
        {
            return this.users.GetById(id);
        }

        //public User GetByUsername(string username)
        //{
        //    //return this.users.All()
        //    //    .Where(x=>x.UserName == username)
        //    //    .
        //}
    }
}
