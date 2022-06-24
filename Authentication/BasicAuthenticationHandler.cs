using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RapidPay.Services.Interfaces;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RapidPay.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IUserService userService,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {  
           if(Request.Headers["Authorization"].SingleOrDefault() is null)
                return AuthenticateResult.Fail($"Authentication failed invalid username or password");

            var basicAuthInfo = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(basicAuthInfo.Parameter)).Split(':');
            var username = credentials[0];
            var password = credentials[1];

            if (!await _userService.IsAuthenticated(username, password))
                return AuthenticateResult.Fail($"Authentication failed invalid username or password");

            var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username)
                };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket); 
        }
    }
}
