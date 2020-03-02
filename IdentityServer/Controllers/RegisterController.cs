using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Entities;
using IdentityServer.Models.RegisterModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        //private readonly GoogleCaptchaService _googleCaptchaService;

        public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var registerModel = new RegisterViewModel();

            return View(registerModel);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true
            };

            var userCreateResult = await _userManager.CreateAsync(user, model.Password);

            if (!userCreateResult.Succeeded)
            {
                userCreateResult.Errors.ToList().ForEach(x => ModelState.AddModelError(x.Code, x.Description));
                return View(model);
            }

            if (!user.EmailConfirmed)
                await SendTokenEmail(user);


            return View("");
        }

        public async Task SendTokenEmail(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }
    }
}