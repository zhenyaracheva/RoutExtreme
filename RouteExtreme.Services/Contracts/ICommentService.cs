namespace RouteExtreme.Services.Contracts
{
    using RouteExtreme.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
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
