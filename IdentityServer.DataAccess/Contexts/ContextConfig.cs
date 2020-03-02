using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.DataAccess.ContextFactories
{
    public class ContextConfig
    {
        public static Action<NpgsqlDbContextOptionsBuilder> MigrationAssembly =
                                               (NpgsqlDbContextOptionsBuilder options) => options.MigrationsAssembly("IdentityServer");
    }
}
