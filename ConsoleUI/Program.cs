using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager product = new ProductManager(new EfProductDal());
           /* foreach (var item in product.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }*/
            decimal min = 500;
            decimal max = 100;
            foreach (var item in product.GetByUnitPrice(min,max))
            {
                Console.WriteLine(item.UnitPrice);
            }

            Console.ReadLine();
        }
    }
}