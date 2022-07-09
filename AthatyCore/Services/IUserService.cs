using AthatyCore.Entities;
namespace AthatyCore.Services
{
    //Any service handling User registration & access (authentication/authorization) must implemented this interface
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest authenticationRequest);

        IEnumerable<User> GetUsers();

        User GetUserById(string id);
    }
}
