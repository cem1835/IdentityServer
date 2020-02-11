using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace IdentityServer.DataAccess
{
    public static class DataAccessConfig
    {
        private static IConfiguration configuration;
        static DataAccessConfig()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,"IdentityServer.DataAccess"))
                .AddJsonFile("IdentityServer.DataAccess.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string Get(string name)
            => configuration[name];
    }
}
