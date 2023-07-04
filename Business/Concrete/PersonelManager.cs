using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IDataResult<List<Personel>> GetAllPersonels()
        {
            return new SuccessDataResult<List<Personel>>(_personelDal.GetAll());
        }

        public IDataResult<Personel> GetPersonels(int id)
        {
            return new SuccessDataResult<Personel>(_personelDal.Get(p=>p.Id==id));
        }
    }
}
