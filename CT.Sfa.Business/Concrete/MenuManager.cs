using CT.Sfa.Business.Abstract;
using CT.Sfa.DataAccess.Abstract;
using CT.Sfa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Sfa.Business.Concrete
{
    public class MenuManager : IMenuService
    {
        private IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }
        public void Add(Menu menu)
        {
            _menuDal.Add(menu);
        }

        public void Delete(int menuId)
        {
            _menuDal.Delete(new Menu { MenuId = menuId });
        }

        public List<Menu> GetAll()
        {
            return _menuDal.GetAll();
        }

        public Menu GetById(int menuId)
        {
            return _menuDal.Get(f => f.MenuId == menuId);
        }

        public void Update(Menu menu)
        {
            _menuDal.Update(menu);
        }
    }
}
