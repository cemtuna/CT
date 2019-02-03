using CT.Sfa.MvcWebUI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.Sfa.MvcWebUI.Requirements
{
    public class DomainHandler : AuthorizationHandler<DomainRequirement>
    {
        private readonly UserManager<User> _userManager;

        public DomainHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, DomainRequirement requirement)
        {
            if(context.User.Identity.IsAuthenticated)
            {
                var username = context.User.Identity.Name;

                var user = await _userManager.FindByNameAsync(username);

                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                if (user.Email.Contains(requirement._domainName) && isAdmin)
                {
                    context.Succeed(requirement);
                    await Task.CompletedTask;
                }
            }

            await Task.CompletedTask;

        }
    }
}
