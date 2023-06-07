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
            ProductManager productm = new ProductManager(new EfProductDal());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            OrderManager orderManager = new OrderManager(new EFOrderDal());
            PersonelManager personelManager = new PersonelManager(new EFPersonelDal());
            GetAlldtoo(productm);

            shipCity(orderManager);
            //Console.WriteLine("{0},{1},{2},{3},{4}",item.OrderId,item.CustomerId,item.EmployeeId,item.OrderDate.ToString(),item.ShipCity);


            //produceGetAll(product, categoryManager);
            //GetAllCategoriess(categoryManager);
            //GettCategoryByNamee(categoryManager);
            //GetAllbyCategory(product);
            //GetAllproducts(product);
            //enumm();
            //maxmin(product);
            personel(personelManager);
            Console.ReadLine();
        }

        private static void GetAlldtoo(ProductManager productm)
        {
            var result = productm.GetAlldto();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine("{0}/{1}/{2}", item.ProductId, item.ProductName, item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void shipCity(OrderManager orderManager)
        {
            var result = orderManager.GetAll();
            if (result.Success)
            {
                foreach (var item in result.Data)
                { 
                    Console.WriteLine(item.ShipCity); 
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void produceGetAll(ProductManager product, CategoryManager categoryManager)
        {
            var d = categoryManager.GetCategoryByName("produce").Data.CategoryId;
            var result = product.GetAllbyCategoryId(d);
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.ProductName + " ------- " + item.CategoryId);
            }
        }

        private static void GettCategoryByNamee(CategoryManager categoryManager)
        {
            var a = categoryManager.GetCategoryByName("produce").Data.CategoryId.ToString();
            Console.WriteLine(a);
        }

        private static void GetAllCategoriess(CategoryManager categoryManager)
        {
            foreach (var item in categoryManager.GetAllCategories().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void personel(PersonelManager personelManager)
        {
            foreach (var item in personelManager.GetAllPersonels().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void GetAllbyCategory(ProductManager product)
        {
            foreach (var item in product.GetAllbyCategoryId(1).Data)
            {
                Console.WriteLine(item.ProductName + "  " + item.CategoryId);
            }
        }

        private static void maxmin(ProductManager product)
        {
            decimal min = 500;
            decimal max = 100;
            foreach (var item in product.GetByUnitPrice(min, max).Data)
            {
                Console.WriteLine(item.UnitPrice);
            }
        }

        private static void GetAllproducts(ProductManager product)
        {
            foreach (var item in product.GetAll().Data)
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