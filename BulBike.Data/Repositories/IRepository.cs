namespace BulBike.Data.Repositories
{
    using Models;
    using System;
    using System.Linq;

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
