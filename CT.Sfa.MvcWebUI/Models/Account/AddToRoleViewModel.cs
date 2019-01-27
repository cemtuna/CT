using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CT.Sfa.MvcWebUI.Models.Account
{
    public class AddToRoleViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
