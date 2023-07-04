using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        ICategoryService _categoryService; //*****

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

       // [SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(ProductValidator))]
       // [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                AnyName(product.ProductName), CategoryCount());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllbyCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<ProductDetailDTO>> GetAlldto()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetAlldto());
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice >= max));
        }
        public IDataResult<Product> GetProduct(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var s = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (s > 100)
            {
                return new ErrorResult("bu kategoriye 10dan fazla ürün eklenemez");
            }
            return new SuccessResult();
        }

        private IResult AnyName(string productName)
        {
            if (_productDal.GetAll(p => p.ProductName == productName).Any())
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CategoryCount()
        {
            var result = _categoryService.GetAllCategories().Data.Count;
            if (result >= 15)
            {
                return new ErrorResult("kategori sayısı 15i geçti artık ürün eklenemez");
            }
            return new SuccessResult();
        }

    }
}
