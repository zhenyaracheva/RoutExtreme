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

        public void Delete(string id)
        {
            var user = this.users.GetById(id);
            if (user == null)
            {
                throw new Exception("No such user id");
            }

            this.users.Delete(user);
            this.users.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All()
                             .Where(x=> !x.IsDeleted);
        }

        public IQueryable<User> GetById(String id)
        {
            return this.GetAll()
                        .Where(u => u.Id == id);
        }

        public IQueryable<User> GetByUsername(string username)
        {
            return this.GetAll()
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

        public void MarkAsDeleted(User user)
        {
            this.users.MarkAsDeleted(user);
            this.users.SaveChanges();
        }
    }
}
