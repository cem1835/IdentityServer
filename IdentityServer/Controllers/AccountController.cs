using IdentityServer.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    public class AccountController : Controller
    {

        //private readonly TestUserStore _users;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

        public AccountController(IIdentityServerInteractionService interaction,IClientStore clientStore,IAuthenticationSchemeProvider schemeProvider,IEventService events)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
        }

        public async Task<IActionResult> Login(string returnUrl)
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
                ReturnUrl=returnUrl,
            };

            return View(model);
        }


    }
}