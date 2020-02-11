using IdentityServer.DataAccess.ContextFactories;
using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.IdentityServerImp;
using IdentityServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.DataAccess
{
    public static class IdentityServerBuilder
    {
        public static void BuildMyIdentityServer(this IServiceCollection services)
        {
            services
                    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(ContextConfig.ConnectionString))

                    .AddIdentityServer(options =>
                    {
                        options.Events.RaiseErrorEvents = true;
                        options.Events.RaiseInformationEvents = true;
                        options.Events.RaiseFailureEvents = true;
                        options.Events.RaiseSuccessEvents = true;
                    })

                    .AddConfigurationStore(option =>
                            option.ConfigureDbContext =
                                builder => builder.UseNpgsql(ContextConfig.ConnectionString, ContextConfig.MigrationAssembly))

                    .AddOperationalStore(option =>
                           option.ConfigureDbContext =
                                builder => builder.UseNpgsql(ContextConfig.ConnectionString, ContextConfig.MigrationAssembly))

                    .AddProfileService<ProfileService>()

                    .AddDeveloperSigningCredential(); // TODO : Change this for production


            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
