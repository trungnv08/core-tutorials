using coreTutorials.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace coreTutorials.Controllers
{
    public class CookieActionhandle : CookieAuthenticationEvents
    {
        private readonly MyDbContext dbContext;
        public CookieActionhandle(MyDbContext context)
        {
            dbContext = context;
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var principal = context.Principal;
            var username = principal.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Name));
            var exp = principal.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Expiration));
            var isValid = (exp != null) && !string.IsNullOrWhiteSpace(exp.Value) && DateTime.UtcNow < DateTime.Parse(exp.Value);
            if (isValid && (username != null) && !string.IsNullOrWhiteSpace(username.Value))
            {
            }
            else
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }


    }
}
