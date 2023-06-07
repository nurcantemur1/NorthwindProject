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
    public interface IPersonelService
    {
        IDataResult<Personel> GetPersonels(int id);
        IDataResult<List<Personel>> GetAllPersonels();   

    }
}
