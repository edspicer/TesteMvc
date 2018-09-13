using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TesteMvc.DAL;
using System.Linq.Expressions;
using TesteMvc.DAL.Context;
using TesteMvc.EF;

namespace TesteMvc.DAL.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        BDContext _ctx = new BDContext();
        


        public void Add(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            _ctx.Set<TEntity>()
                 .Where(predicate).ToList()
                 .ForEach(del => _ctx.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public TEntity Find(params object[] key)
        {
            return _ctx.Set<TEntity>().Find(key);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }
    }
}
