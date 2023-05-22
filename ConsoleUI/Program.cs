using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager product = new ProductManager(new InMemoryProductDal());
            foreach (var item in product.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }

            Console.ReadLine();
        }
    }
}