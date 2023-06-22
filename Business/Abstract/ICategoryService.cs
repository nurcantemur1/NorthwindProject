using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAllCategories();
        IDataResult<Category>  GetCategoryById(int id);
        IDataResult<Category> GetCategoryByName(string name);
        IResult Add(Category category);
    }
}
