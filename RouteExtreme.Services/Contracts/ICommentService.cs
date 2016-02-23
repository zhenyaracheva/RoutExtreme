namespace RouteExtreme.Services.Contracts
{
    using System.Linq;
    using RouteExtreme.Models;

    public interface ICommentService
    {
        void Create(Comment comment);

        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetById(int id);
        
        void Update(Comment updatedComment);

        void Delete(int id);

        void MarkAsDeleted(Comment comment);
    }
}
