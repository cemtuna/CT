using CT.Sfa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Sfa.Business.Abstract
{
    public interface IMenuService
    {
        List<Menu> GetAll();
        void Add(Menu menu);
        void Update(Menu menu);
        void Delete(int menuId);
        Menu GetById(int menuId);
    }
}
