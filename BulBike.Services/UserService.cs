namespace BulBike.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Repositories;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class UserService : IUserService
    {
        private IRepository<User> users;
        private UserManager<User> userManager;

        public UserService(IRepository<User> users)
        {
            this.users = users;
            this.userManager = new UserManager<User>(new UserStore<User>(new BulBikeDbContext()));
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

        public void Create(User user, string password)
        {
            this.userManager.Create(user, password);
            this.userManager.AddToRole(user.Id, "user");
        }
    }
}
