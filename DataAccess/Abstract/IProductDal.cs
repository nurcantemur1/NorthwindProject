using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //dal-dao data accces layer
    //veri tabanında yapılacak operasyonlar yazılır
    public interface IProductDal : IEntityRepository<Product>
    {
        //producta özel join operasyonları yer alacak
       // List<ProductDto> GetAll();
    }
}
