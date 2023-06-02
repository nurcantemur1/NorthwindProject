﻿using Business.Abstract;
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

        public List<Personel> GetAllPersonels()
        {
            return _personelDal.GetAll();
        }

        public Personel GetPersonels(int id)
        {
            return _personelDal.Get(p=>p.Id==id);
        }
    }
}
