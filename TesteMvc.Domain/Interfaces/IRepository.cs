
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TesteMvc.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(params object[] key);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Func<TEntity, bool> predicate);
        void Commit();
        void Dispose();
    }
}
