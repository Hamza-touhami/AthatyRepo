using AthatyCore.Entities;
using AthatyCore.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AthatyCore.Services
{
    //This service is used to handle Users and authentication/authorization
    public class UserService : IUserService
    {
        //For now, users are hardcoder, later, the must be stored in DB with hashed passwords
        private List<User> users = new List<User>
        {
            new User() {Id = "e6318827-f762-488b-a724-116c6d18e81e", FirstName = "Hamid", LastName = "Machamid", UserName = "Hamidos", Password = "Password1"},
            new User() {Id = "c30dae7e-c12d-41dc-86d1-4eb3a84206c3", FirstName = "Said", LastName = "Said", UserName = "Saidos", Password = "Password2"},
        };

        private string secretKey;

        public UserService(IOptions<AuthenticationSettings> settings)
        {
            var authSettngs = settings.Value;
            if(authSettngs != null)
                this.secretKey = authSettngs.SecretKey;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest authenticationRequest)
        {
            var user = users.FirstOrDefault(x => x.UserName.Equals(authenticationRequest.UserName) && x.Password.Equals(authenticationRequest.Password));

            if (user == null)
                return null;

            var token = createToken(user.Id);

            return new AuthenticationResponse() { User = user, Token = token };
      
        }

        public User GetUserById(string id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        private string createToken(string userId)
        {
            //Generate token that is valid for 7 days
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", userId), new Claim(ClaimTypes.Role, "Admin")}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
