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
            using (NorthwindContex contex = new NorthwindContex())
            {
                contex.Add(entity);
                contex.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                contex.Set<Product>().Remove(contex.Set<Product>().SingleOrDefault(p=>p.ProductId==entity.ProductId));
                contex.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                return contex.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                return filter==null 
                    ? contex.Set<Product>().ToList()
                    : contex.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                var up=contex.Set<Product>().SingleOrDefault(p=>p.ProductId==entity.ProductId);
                up.ProductName= entity.ProductName;
                up.UnitPrice= entity.UnitPrice;
                up.UnitsInStock= entity.UnitsInStock;
                up.CategoryId= entity.CategoryId;
                contex.SaveChanges();
            }
        }
    }
}
