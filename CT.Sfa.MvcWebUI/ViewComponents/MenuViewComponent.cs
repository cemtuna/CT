using CT.Sfa.Business.Abstract;
using CT.Sfa.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.Sfa.MvcWebUI.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private IMenuService _menuService;
        public MenuViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public ViewViewComponentResult Invoke()
        {
            var menuViewModel = new MenuViewModel
            {
                Menus = _menuService.GetAll()
            };

            return View(menuViewModel);
        }
    }
}
