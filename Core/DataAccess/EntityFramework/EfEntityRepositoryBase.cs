using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var add=contex.Set<TEntity>().Entry(entity);
                add.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var delete =contex.Set<TEntity>().Entry(entity);
                delete.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext contex = new TContext())
            {
                return contex.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext contex = new TContext())
            {
                return filter == null
                    ? contex.Set<TEntity>().ToList()
                    : contex.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var up = contex.Set<TEntity>().Entry(entity);
                up.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
