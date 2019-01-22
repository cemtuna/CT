using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Sfa.MvcWebUI.Entities
{
    public class User:IdentityUser
    {
        public int UserId { get; set; }
        public string UserFull { get; set; }
        public int UserTypeId { get; set; }
        public int FirmId { get; set; }
        public int DealerId { get; set; }
        public DateTime BirthDate { get; set; }
        public int MaritalStatus { get; set; }
        public string TcIdentity { get; set; }
    }
}
