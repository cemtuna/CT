using Microsoft.AspNetCore.Authorization;

namespace CT.Sfa.MvcWebUI.Requirements
{
    public class AccessRequirement: IAuthorizationRequirement
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public AccessRequirement(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
    }
}