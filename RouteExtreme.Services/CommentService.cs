namespace RouteExtreme.Services
{
    using System;
    using System.Linq;
    using RouteExtreme.Services.Contracts;
    using Data.Repositories;
    using Models;
    
    public class CommentService : ICommentService
    {
        private IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Delete(int id)
        {
            var comment = this.comments.GetById(id);
            if (comment == null)
            {
                throw new Exception("No such user id");
            }

            this.comments.Delete(comment);
            this.comments.SaveChanges();
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All();
        }

        public IQueryable<Comment> GetById(int id)
        {
            return this.comments
                        .All()
                        .Where(u => u.Id == id);
        }
        
        public void Update(Comment comment)
        {
            this.comments.Update(comment);
            this.comments.SaveChanges();
        }

        public void Create(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }

        public void MarkAsDeleted(Comment comment)
        {
            this.comments.MarkAsDeleted(comment);
            this.comments.SaveChanges();
        }
    }
}
