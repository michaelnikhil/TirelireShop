using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TirelireShop.ViewModels;
using System.Security.Claims;
using TirelireShop.DataAccess;
using TirelireShop.Repository;
using Microsoft.AspNetCore.Http;

namespace TirelireShop.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IRepository<Client> repoClient;
        private DBTirelireShopContext ctx;

        public AccountController(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            ctx = new DBTirelireShopContext();
            repoClient = new RepositoryTirelire<Client>(ctx);
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginPost(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    //retrieve user email and compare to Client table
                    var appUser = _signInManager.UserManager.Users.FirstOrDefault();
                    string user_email = appUser.Email;

                    int? IdClient = repoClient.GetAll()
                        .Where(c => c.Email == user_email)
                        .Select(c => c.Idclient).FirstOrDefault();

                    if (IdClient != null) {
                        //store client ID in session
                        HttpContext.Session.Remove("IdClient");
                        HttpContext.Session.SetString("IdClient", IdClient.ToString());
                    }
                    else
                    {
                        return RedirectToAction("Register", "Account");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Failed to Login");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPost(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {  //1. Update Identity context
                IdentityUser user = new IdentityUser
                {
                    
                    UserName = registerModel.UserName,
                    PhoneNumber = registerModel.PhoneNumber,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    bool roleExists = await _roleManager.RoleExistsAsync(registerModel.RoleName);
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(registerModel.RoleName));
                    }

                    if (!await _userManager.IsInRoleAsync(user, registerModel.RoleName))
                    {
                        await _userManager.AddToRoleAsync(user, registerModel.RoleName);
                    }

                    if (!string.IsNullOrWhiteSpace(user.Email))
                    {
                        Claim claim = new Claim(ClaimTypes.Email, user.Email);
                        await _userManager.AddClaimAsync(user, claim);
                    }

                    var resultSignIn = await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password, registerModel.RememberMe, false);
                    if (resultSignIn.Succeeded)
                    {
                        if (registerModel.RoleName == "Client")
                        {
                            //2. Update DBTirelireShop context
                            Client client = new Client
                            {
                                Nom = registerModel.LastName,
                                Prenom = registerModel.FirstName,
                                Email = registerModel.Email,
                                StatutCompte = true
                            };
                            repoClient.InsertItem(client);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
