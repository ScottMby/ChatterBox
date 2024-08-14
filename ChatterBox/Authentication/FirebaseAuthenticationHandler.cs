using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Extensions.Logging;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace ChatterBox.Authentication
{
    public class FirebaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly FirebaseApp _firebaseApp;

        public FirebaseAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, FirebaseApp firebaseApp) : base(options, logger, encoder)
        {
            _firebaseApp = firebaseApp;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Context.Request.Headers.ContainsKey("Authorization")) //If no auth header. Don't authenticate.
            {
                return AuthenticateResult.NoResult();
            }

            string bearerToken = Context.Request.Headers["Authorization"];

            if (bearerToken == null || !bearerToken.StartsWith("Bearer ")) //If auth token isn't correct, fail auth.
            {
                return AuthenticateResult.Fail("Invalid Scheme. ");

            }

            string token = bearerToken.Substring("Bearer ".Length);

            try
            {
                FirebaseToken firebaseToken = await FirebaseAuth.GetAuth(_firebaseApp).VerifyIdTokenAsync(token); //Verify Auth Token.

                return AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(new List<ClaimsIdentity>() //Return Auth Success.
            {
                new ClaimsIdentity(ToClaims(firebaseToken.Claims))
            }), JwtBearerDefaults.AuthenticationScheme));
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex);
                Log.Logger.Debug($"Exeception Thrown: {ex}", ex);
            }
        }

        private IEnumerable<Claim>? ToClaims(IReadOnlyDictionary<string, object> claims)
        {
            return new List<Claim>
            {
                new Claim("id", claims["user_id"].ToString()),
                new Claim("email", claims["email"].ToString()),
                new Claim("username", claims["username"].ToString()),
            };
        }
    }
}
