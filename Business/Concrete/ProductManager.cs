using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // return new DataResult<List<Product>>(_productDal.GetAll(),true);
            if (2==2)
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetAll());
            }

            return new ErrorDataResult<List<Product>>(Messages.ProductNameInvalid);
        }

        public IDataResult<List<Product> > GetAllbyCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id),true);
        }

        public IDataResult<List<ProductDetailDTO>> GetAlldto()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetAlldto(),true);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice<=min && p.UnitPrice>=max),true);
        }

        public IDataResult<Product> GetProduct(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==id), true);
        }
    }
}
