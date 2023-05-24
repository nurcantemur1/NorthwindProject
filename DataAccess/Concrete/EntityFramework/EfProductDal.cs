using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindCortex cortex = new NorthwindCortex())
            {
                var added=cortex.Entry(entity);
                added.State = EntityState.Added;
                cortex.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindCortex cortex = new NorthwindCortex())
            {
                var deleted = cortex.Entry(entity);
                deleted.State = EntityState.Deleted;
                cortex.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindCortex cortex=new NorthwindCortex())
            {
                return cortex.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindCortex cortex=new NorthwindCortex())
            {
                return filter==null 
                    ? cortex.Set<Product>().ToList()
                    : cortex.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindCortex cortex = new NorthwindCortex())
            {
                var updated = cortex.Entry(entity);
                updated.State = EntityState.Modified;
                cortex.SaveChanges();
            }
        }
    }
}
