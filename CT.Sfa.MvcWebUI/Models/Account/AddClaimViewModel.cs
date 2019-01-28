using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CT.Sfa.MvcWebUI.Entities;

namespace CT.Sfa.MvcWebUI.Models.Account
{
    public class AddClaimViewModel
    {
        
        public string UserName { get; set; }
        
        public string RoleName { get; set; }

        [Required]
        public string ClaimName { get; set; }

        [Required]
        public string ClaimValue { get; set; }

        public List<User> UserList { get; internal set; }

        public List<Role> RoleList { get; internal set; }
    }
}
