using CT.Sfa.MvcWebUI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.Sfa.MvcWebUI.ViewComponents
{
    public class LoginViewComponent:ViewComponent
    {
        private UserManager<User> _userManager;
        public LoginViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }
}
