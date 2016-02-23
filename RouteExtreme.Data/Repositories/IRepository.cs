namespace RouteExtreme.Data.Repositories
{
    using System;
    using System.Linq;

    using Models;
    
    public interface IRepository<T> : IDisposable
        where T : class, IDeletableEntity, IAuditInfo
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        void MarkAsDeleted(T entity);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
