using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class GoogleReCaptchaModel
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
    }
}
