using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashOnLedgerAPI.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Method)]
    public class ApiKeyCheckAttribute : Attribute, IAsyncActionFilter
    {
        private const string APITOKENNAME = "API_TOKEN";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APITOKENNAME, out var extractedApiKey))
            {
                 throw new UnauthorizedAccessException();
            }

            var apiKey = Environment.GetEnvironmentVariable(APITOKENNAME);

            if (!apiKey.Equals(extractedApiKey))
            {
                throw new UnauthorizedAccessException();
            }

            await next();
        }
    }
}
