using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Middleware
{
    public class SecurityHeadersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result;

            if (result is ViewResult)
            {
                var header = context.HttpContext.Response.Headers;

                if (!header.ContainsKey("X-Content-Type-Options"))
                    header.Add("X-Content-Type-Options", "nosniff");

                if (!header.ContainsKey("X-Frame-Options"))
                    header.Add("X-Frame-Options", "SAMEORIGIN");

                var csp = "default-src 'self'; object-src 'none'; frame-ancestors 'none'; sandbox allow-forms allow-same-origin allow-scripts; base-uri 'self';";

                if (!header.ContainsKey("Content-Security-Policy"))
                    header.Add("Content-Security-Policy", csp);

                if (!header.ContainsKey("X-Content-Security-Policy"))
                    header.Add("X-Content-Security-Policy", csp);

                if (!header.ContainsKey("Referrer-Policy"))
                    header.Add("Referrer-Policy", "no-referrer");
            }
        }


    }
}
