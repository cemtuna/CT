using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.Sfa.MvcWebUI.Requirements
{
    public class DomainRequirement:IAuthorizationRequirement
    {
        public string _domainName { get; set; }

        public DomainRequirement(string domainName)
        {
            _domainName = domainName;
        }
    }
}
