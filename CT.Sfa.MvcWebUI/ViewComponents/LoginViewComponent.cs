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
        public LoginViewComponent()
        {

        }

        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }
}
