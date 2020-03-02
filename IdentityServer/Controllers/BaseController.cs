using DTemplate.Common.Authentication.ValidationAttributes;
using DTemplate.Common.MVC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [ServiceFilter(typeof(ModelActionFilter))]
    public class BaseController:CommonMVCController
    {
        
    }
}
