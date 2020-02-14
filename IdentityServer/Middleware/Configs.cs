using AutoMapper.Configuration;
using IdentityServer.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Middleware
{
    public static class AppSettingConfigs
    {
        public static IServiceCollection AddConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<GoogleReCaptchaModel>(configuration("GoogleReCaptcha"));

            return services;
        }
    }
}
