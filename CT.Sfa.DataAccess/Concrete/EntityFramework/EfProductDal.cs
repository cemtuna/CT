using CT.Core.DataAccess.EntityFramework;
using CT.Sfa.DataAccess.Abstract;
using CT.Sfa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Sfa.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,AppContext>,IProductDal
    {
    }
}
