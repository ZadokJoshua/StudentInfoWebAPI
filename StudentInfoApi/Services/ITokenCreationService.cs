using Microsoft.AspNetCore.Identity;
using StudentInfoAPI.ResourceModels;

namespace StudentInfoAPI.Services
{
    public interface ITokenCreationService
    {
        AuthenticationResponse CreateToken(IdentityUser user);
    }
}