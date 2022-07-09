using AthatyCore.Helpers;
using AthatyCore.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AthatyCore.CustomMiddlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        private readonly string secretKey;

        public JwtMiddleware(RequestDelegate next, IOptions<AuthenticationSettings> settings)
        {
            this.next = next;
            var authSettngs = settings.Value;
            if (authSettngs != null)
                this.secretKey = authSettngs.SecretKey;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if(token != null)
            {
                //Validate token
                var jwtToken = validateToken(token);
                //Get user from token successful validated token and attach it to context
                if(jwtToken != null)
                {
                    var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == "id");

                    if (claim != null)
                    {
                        var userId = claim.Value;
                        context.Items["User"] = userService.GetUserById(userId);
                    }
                    //Do nothing, if authentication failed, user won't be attached to context, and OnAuthorized will therefore return Unauthorized
                }

            }

            await next(context); //pass to next middleware

        }
        private JwtSecurityToken validateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //set clockskew to 0 so that tokens expire exactly at token expiration time (instead of 5min later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return validatedToken as JwtSecurityToken;
            }
            catch
            {
                //Do nothing, if authentication failed, user won't be attached to context, and OnAuthorized will therefore return Unauthorized
                return null;
            }

        }
       
    }
}
