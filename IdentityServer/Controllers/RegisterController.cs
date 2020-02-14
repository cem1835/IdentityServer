using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    public class RegisterController : Controller
    {
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}