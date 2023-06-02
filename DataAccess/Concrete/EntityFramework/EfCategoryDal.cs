using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                contex.Add(entity);
                contex.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (NorthwindContex context=new NorthwindContex())
            {
                context.Set<Category>().Remove(context.Set<Category>().SingleOrDefault(p=>p.CategoryId==entity.CategoryId));
                context.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                return contex.Set<Category>().SingleOrDefault(filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                return filter == null
                    ? contex.Set<Category>().ToList()
                    : contex.Set<Category>().Where(filter).ToList();
            }
        }

        public void Update(Category entity)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                var d= contex.Set<Category>().SingleOrDefault(p=>p.CategoryId==entity.CategoryId);
                d.CategoryName= entity.CategoryName;
                d.Description= entity.Description;
                contex.SaveChanges();
            }
        }
    }
}
