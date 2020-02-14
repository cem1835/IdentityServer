using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityServer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
