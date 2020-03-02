using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Entities
{
    public class ApplicationConfiguration:BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
