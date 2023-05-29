using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        enum gg
        {
            windows = 99, linux = 123,
        }
        static void Main(string[] args)
        {
            ProductManager product = new ProductManager(new EfProductDal());
            GetAllproducts(product);
          //  enumm();
           // maxmin(product);
            Console.ReadLine();
        }

        private static void maxmin(ProductManager product)
        {
            decimal min = 500;
            decimal max = 100;
            foreach (var item in product.GetByUnitPrice(min, max))
            {
                Console.WriteLine(item.UnitPrice);
            }
        }

        private static void GetAllproducts(ProductManager product)
        {
            foreach (var item in product.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void enumm()
        {
            var gg = new gg();
            int a = 99;
            var gdg = (gg)a;
            Console.WriteLine(gdg.ToString());
        }
    }
}