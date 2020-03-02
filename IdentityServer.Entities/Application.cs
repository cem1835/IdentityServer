using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Entities
{
    public class Application:BaseEntity
    {
        public string AppName { get; set; }
        public string Description { get; set; }
    }
}
