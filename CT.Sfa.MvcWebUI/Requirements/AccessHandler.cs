using CT.Sfa.MvcWebUI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.Sfa.MvcWebUI.Requirements
{
    public class AccessHandler : AuthorizationHandler<AccessRequirement>
    {
        private readonly UserManager<User> _userManager;

        public AccessHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                //var username = context.User.Identity.Name;

                //var user = await _userManager.FindByNameAsync(username);

                //var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                if (context.User.HasClaim(f=>f.Type==requirement.ClaimType && f.Value==requirement.ClaimValue))
                {
                    context.Succeed(requirement);
                    await Task.CompletedTask;
                }
            }

            await Task.CompletedTask;
        }
    }
}
