using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.DataAccess.ContextFactories
{
    public class ContextConfig
    {
        public static string ConnectionString = DataAccessConfig.Get("IdentityServerConnection");

        public static Action<NpgsqlDbContextOptionsBuilder> MigrationAssembly =
                                               (NpgsqlDbContextOptionsBuilder options) => options.MigrationsAssembly("IdentityServer.DataAccess");


        public static void GetConfig<T>() where T:DbContext
        {
            var builder = new DbContextOptionsBuilder<T>();
        }
    }
}
