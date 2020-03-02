using IdentityServer.DataAccess.ContextFactories;
using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.IdentityServerImp;
using IdentityServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.DataAccess
{
    public static class IdentityServerBuilder
    {
        public static void BuildMyIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services
            .Configure<IdentityOptions>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
                o.Password.RequiredUniqueChars = 0;
            })
            .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString))
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddConfigurationStore(option => option.ConfigureDbContext = builder => builder.UseNpgsql(connectionString, ContextConfig.MigrationAssembly))

            .AddOperationalStore(option => option.ConfigureDbContext = builder => builder.UseNpgsql(connectionString, ContextConfig.MigrationAssembly))

            .AddProfileService<ProfileService>()
            .AddDeveloperSigningCredential(); // TODO : Change this for production


            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();


        }
    }
}
