// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Autofac;
using Autofac.Features.AttributeFilters;
using DTemplate.Common.Authentication.ValidationAttributes;
using DTemplate.Common.Mailing;
using DTemplate.Common.Middlewares;
using IdentityServer.DataAccess;
using IdentityServer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.BuildMyIdentityServer(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.UseSmtpMailSender(new SmtpConfiguration());
            builder.RegisterType<ModelActionFilter>().WithAttributeFiltering();
            builder.RegisterInstance(Configuration).As<IConfiguration>();

        }


        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}