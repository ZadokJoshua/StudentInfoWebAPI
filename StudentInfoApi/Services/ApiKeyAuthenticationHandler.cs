﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentInfoAPI.Data;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace StudentInfoAPI.Services
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string API_KEY_HEADER = "Api-Key";

        private readonly StudentInfoDbContext _studentInfoDbContext;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            StudentInfoDbContext studentInfoDbContext
        ) : base(options, logger, encoder, clock)
        {
            _studentInfoDbContext = studentInfoDbContext;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(API_KEY_HEADER))
            {
                return AuthenticateResult.Fail("Header Not Found.");
            }

            string apiKeyToValidate = Request.Headers[API_KEY_HEADER];

            var apiKey = await _studentInfoDbContext.UserApiKeys
                .Include(uak => uak.User)
                .SingleOrDefaultAsync(uak => uak.Value == apiKeyToValidate);

            if (apiKey == null)
            {
                return AuthenticateResult.Fail("Invalid key.");
            }

            return AuthenticateResult.Success(CreateTicket(apiKey.User));
        }

        private AuthenticationTicket CreateTicket(IdentityUser user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return ticket;
        }
    }
}
