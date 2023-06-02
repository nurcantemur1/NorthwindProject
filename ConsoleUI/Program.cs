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
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var item in product.GetAllbyCategoryId(categoryManager.GetCategoryByName("produce").CategoryId))
            {
                Console.WriteLine(item.ProductName+" ------- "+item.CategoryId);
            }
           
            
            /*  foreach (var item in categoryManager.GetAllCategories()) 
              {
                  Console.WriteLine(item.CategoryName);
              }*/
            var a=categoryManager.GetCategoryByName("produce").CategoryId.ToString();
            Console.WriteLine(a);


            // GetAllbyCategory(product);
            //  GetAllproducts(product);
            //  enumm();
            // maxmin(product);
            // personel();
            Console.ReadLine();
        }

        private static void personel()
        {
            PersonelManager personelManager = new PersonelManager(new EFPersonelDal());
            foreach (var item in personelManager.GetAllPersonels())
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void GetAllbyCategory(ProductManager product)
        {
            foreach (var item in product.GetAllbyCategoryId(1))
            {
                Console.WriteLine(item.ProductName + "  " + item.CategoryId);
            }
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