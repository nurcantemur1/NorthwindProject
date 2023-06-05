using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager:IOrderService
    {
        IOrderDal _orderdal;

        public OrderManager(IOrderDal orderdal)
        {
            _orderdal = orderdal;
        }

        public List<Order> GetAll()
        {
            return _orderdal.GetAll();
        }

        public Order GetOrder(int id)
        {
            return _orderdal.Get(p=>p.OrderId==id);
        }
    }
}
