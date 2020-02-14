using IdentityServer.Entities;
using IdentityServer.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    public class LoginController : Controller
    {

        //private readonly TestUserStore _users;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;
        
        public LoginController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IIdentityServerInteractionService interaction,IClientStore clientStore,IAuthenticationSchemeProvider schemeProvider,IEventService events)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            var model = await GetLoginViewModel(returnUrl);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = await GetLoginViewModel(model.ReturnUrl);
                errorModel.RememberLogin = model.RememberLogin;
                errorModel.Username = model.Username;

                return View(errorModel);
            }

            var result = await _signInManager.PasswordSignInAsync("", "",false,false);


                return View(model);
        }

        public async  Task<LoginViewModel> GetLoginViewModel(string returnUrl)
        {
            var schemes = await _schemeProvider.GetAllSchemesAsync();

            // externalProviders like google login,facebook login etc.
            var externalProviders = schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            // TODO : Implement External Provider To View !
            var model = new LoginViewModel
            {
                ExternalProviders = externalProviders,
                ReturnUrl = returnUrl,
            };

            return model;
        }


    }
}