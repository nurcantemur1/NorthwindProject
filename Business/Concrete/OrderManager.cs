using Business.Abstract;
using Core.Utilities.Results.DataResults;
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

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderdal.GetAll());
        }

        public IDataResult<Order> GetOrder(int id)
        {
            return new SuccessDataResult<Order>(_orderdal.Get(p=>p.OrderId==id));
        }
    }
}
