using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult("eklendi");
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.CategoryListed);
        }

        public IDataResult<Category> GetCategoryById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p=>p.CategoryId==id));    
        }

        public IDataResult<Category> GetCategoryByName(string name)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p=>p.CategoryName==name));
        }
    }
}
