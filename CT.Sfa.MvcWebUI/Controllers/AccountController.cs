using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CT.Sfa.MvcWebUI.Entities;
using CT.Sfa.MvcWebUI.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CT.Sfa.MvcWebUI.Controllers
{

    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = new User
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callBackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = confirmationCode.Result });

                //Send Mail

                var role = await _roleManager.FindByNameAsync("User");
                if (role == null)
                {
                    var roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = "User"
                    });
                }

                if (role != null)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (!addRoleResult.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, string.Format("User couldn't be added to {0} role!", "User"));
                        return View(registerViewModel);
                    }
                }

                return RedirectToAction("Login", "Account");
            }

            return View(registerViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Register", "Account");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException("Unable to find the user.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Confirm your email please!");
                    return View(loginViewModel);
                }
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Login failed");
            return View(loginViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Signout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult AddToRole()
        {
            var model = new AddToRoleViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> AddToRole(AddToRoleViewModel addToRoleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addToRoleViewModel);
            }

            var user = await _userManager.FindByNameAsync(addToRoleViewModel.UserName);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Confirm your email please!");
                    return View(addToRoleViewModel);
                }
            }

            var role = await _roleManager.FindByNameAsync(addToRoleViewModel.RoleName);
            if (role == null)
            {
                var roleResult = await _roleManager.CreateAsync(new Role
                {
                    Name = addToRoleViewModel.RoleName
                });

                //ModelState.AddModelError(string.Empty, "Role not found!");
                //return View(addToRoleViewModel);
            }

            if (role != null)
            {
                var userRoleResult = await _userManager.IsInRoleAsync(user, addToRoleViewModel.RoleName);
                if (userRoleResult)
                {
                    ModelState.AddModelError(string.Empty, string.Format("User is already in {0} role!", addToRoleViewModel.RoleName));
                    return View(addToRoleViewModel);
                }
                else
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, addToRoleViewModel.RoleName);
                    if (addRoleResult.Succeeded)
                    {

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, string.Format("User couldn't be added to {0} role!", addToRoleViewModel.RoleName));
                        return View(addToRoleViewModel);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult AddClaim()
        {
            var model = new AddClaimViewModel
            {
                UserList = _userManager.Users.ToList(),
                RoleList = _roleManager.Roles.ToList()
            };


            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> AddClaim(AddClaimViewModel addClaimViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addClaimViewModel);
            }

            var claim = new Claim(addClaimViewModel.ClaimName, addClaimViewModel.ClaimValue);

            if (!string.IsNullOrEmpty(addClaimViewModel.UserName))
            {
                var user = await _userManager.FindByNameAsync(addClaimViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found!");
                    return View(addClaimViewModel);
                }

                var result = await _userManager.AddClaimAsync(user, claim);
            }
            else if (!string.IsNullOrEmpty(addClaimViewModel.RoleName))
            {
                var role = await _roleManager.FindByNameAsync(addClaimViewModel.RoleName);
                if (role == null)
                {
                    ModelState.AddModelError(string.Empty, "Role not found!");
                    return View(addClaimViewModel);
                }

                var result = await _roleManager.AddClaimAsync(role, claim);
            }



            return RedirectToAction("Index", "Product");
        }

        public IActionResult ResetPassword()
        {
            //private IAuthorizationService _authorizationService;
            return View();
        }

        //[Authorize(Policy = "RequireAdministratorRole")]
        [Authorize(Policy = "DomainPolicy")]
        public IActionResult Index()
        {
            var userViewModel = new UserListViewModel
            {
                Users = _userManager.Users.ToList()
            };
            return View(userViewModel);
        }

        [Authorize]
        public IActionResult Update(string userId)
        {
            var user = _userManager.Users.Where(f => f.Id == userId).FirstOrDefault();
            return View(user);
        }

    }
}