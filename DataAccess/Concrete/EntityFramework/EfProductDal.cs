using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContex>, IProductDal
    { //linq ile join
        public List<ProductDetailDTO> GetAlldto()
        {
            using (NorthwindContex contex =new NorthwindContex())
            {

                var result = from p in contex.Products
                             join c in contex.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDTO{ProductId=p.ProductId,ProductName=p.ProductName,CategoryName=c.CategoryName,UnitInStock=p.UnitsInStock };
                return result.ToList();
                    
            }
        }
    }
}
