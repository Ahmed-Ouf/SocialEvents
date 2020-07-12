using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface IServiceBase<T> where T : AuditableEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllAtive();

        T GetById(Guid id);

        void Add(T model);

        void Update(T model);

        void Deactivate(T model);

        void Activate(T model);

        void SaveChanges();

    }

    public class ServiceBase<T> : IServiceBase<T> where T : AuditableEntity,new()
    {
        private readonly IRepository<T> repo;
        protected readonly IUnitOfWork unitOfWork;

        public ServiceBase(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            this.repo = repository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public virtual IEnumerable<T> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public virtual IEnumerable<T> GetAllAtive()
        {
            return repo.GetAll().Where(e=> e.Active).ToList();
        }

        public virtual T GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public virtual void Add(T model)
        {
            repo.Add(model);
        }

        public virtual void Update(T model)
        {
            repo.Update(model);
        }
        public void Deactivate(T model)
        {
            repo.Deactivate(model);
        }
        public virtual void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Activate(T model)
        {
            repo.Activate(model);
        }

        #endregion ICategoryService Members
    }
}