using SocialEvents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SocialEvents.Data.Infrastructure
{
    public interface IRepository<T> where T : AuditableEntity
    {
        // Marks an entity as new
        void Add(T entity, bool autoId = true);

        // Marks an entity as new
        void AddRange(IEnumerable<T> entities);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        void RemoveRange(IEnumerable<T> entities);

        // Get an entity by int id
        T GetById(object id);

        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);

        // Gets all entities of type T
        IQueryable<T> GetAll();

        // Gets entities using delegate
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Deactivate(object Id);

        void Deactivate(T entity);
        void Activate(T entity);

        IQueryable<T> Where(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            params Expression<Func<T, object>>[] includes);
    }
}