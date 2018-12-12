using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
//using Sample;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Host.SystemWeb;

[assembly: OwinStartup(typeof(RatingsPro.Web.Startup))]

namespace RatingsPro.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            string baseClientAddress = "http://localhost:55717/"; //replace with appSetting

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();// = new Dictionary<string, string>();

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "mvc.standard",
                Authority = "http://localhost:5000/",// replace with appSetting
                RedirectUri = baseClientAddress + "signin-oidc",
                PostLogoutRedirectUri = baseClientAddress + "signout-callback-oidc",
                ResponseType = "code id_token",
                Scope = "openid api1 offline_access",

                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",
                RequireHttpsMetadata = false
            });
        }
    }
}
