using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
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


        [ValidationAspect(typeof(ProductValidator))]
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

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<Product>> GetAllbyCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), true);
        }

        public IDataResult<List<ProductDetailDTO>> GetAlldto()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetAlldto(), true);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice >= max), true);
        }

        public IDataResult<Product> GetProduct(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id), true);
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
