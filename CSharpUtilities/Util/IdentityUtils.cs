using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace DotNet_CSharp.Util
{
    public static class IdentityUtils
    {
        public const String ROLE_ADMIN = "Admin";
        public const String ROLE_OWNER = "Owner";

        #region "Authentication"

        public static ClaimsIdentity getOwnerClaim()
        {
            return new ClaimsIdentity
                    (
                        new List<Claim> { new Claim(ClaimTypes.Role, ROLE_OWNER) },
                        CookieAuthenticationDefaults.AuthenticationScheme
                    );
        }

        public static ClaimsPrincipal getAdminClaim()
        {
            return new ClaimsPrincipal(new ClaimsIdentity
                    (
                        new List<Claim> { new Claim(ClaimTypes.Role, ROLE_ADMIN) },
                        CookieAuthenticationDefaults.AuthenticationScheme
                    ));
        }

        public static AuthenticationProperties getAdminAuthProperties()
        {
            return new AuthenticationProperties
            {
                AllowRefresh = true,
                IssuedUtc = DateTimeOffset.UtcNow,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(90),
                IsPersistent = true
            };

        }

        #endregion

    }
}
