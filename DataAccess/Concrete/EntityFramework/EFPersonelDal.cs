using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFPersonelDal : IPersonelDal
    {
        public void Add(Personel entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                contex.Set<Personel>().Add(entity);
                contex.SaveChanges();
            }
        }

        public void Delete(Personel entity)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                contex.Set<Personel>().Remove(contex.Set<Personel>().FirstOrDefault(p=>p.Id==entity.Id));
                contex.SaveChanges();
            }
        }

        public Personel Get(Expression<Func<Personel, bool>> filter)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                return contex.Set<Personel>().SingleOrDefault(filter);
            }
        }

        public List<Personel> GetAll(Expression<Func<Personel, bool>> filter = null)
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                return filter == null
                    ? contex.Set<Personel>().ToList()
                    : contex.Set<Personel>().Where(filter).ToList();
            }
        }

        public void Update(Personel entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                var up = contex.Set<Personel>().FirstOrDefault(p => p.Id == entity.Id);
                up.Name=entity.Name;
                up.Surname=entity.Surname;
                contex.SaveChanges();
            }
        }
    }
}
