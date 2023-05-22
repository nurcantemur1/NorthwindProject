using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> 
            { 
                new Product {ProductId=1,CategoryId=1,ProductName="a",UnitPrice=4,UnitsInStock=5 },
                new Product {ProductId=2,CategoryId=2,ProductName="b",UnitPrice=5,UnitsInStock=1 },
                new Product {ProductId=3,CategoryId=1,ProductName="c",UnitPrice=6,UnitsInStock=2 },
                new Product {ProductId=4,CategoryId=3,ProductName="d",UnitPrice=8,UnitsInStock=3 },
                new Product {ProductId=5,CategoryId=1,ProductName="e",UnitPrice=14,UnitsInStock=5 }
            };
        }


        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product product1 = _products.SingleOrDefault(p =>product.ProductId==p.ProductId);
            _products.Remove(product1);
        }

        public List<Product> GetAll()
        {
           return _products;
        }

        public List<Product> GetAllbyCategory(int categoryId)
        {
            /* List<Product> productsr = new List<Product>();
             productsr.Add(_products.Find(p=>p.CategoryId == categoryId));
             return productsr;
            */
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product product1 = _products.Find(p=> p.ProductId==product.ProductId);      
            product1.ProductName= product.ProductName;
            product1.UnitPrice= product.UnitPrice;
            product1.UnitsInStock= product.UnitsInStock;
            product1.ProductId= product.ProductId;
        }

    }
}
