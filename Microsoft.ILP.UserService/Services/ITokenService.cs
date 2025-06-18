using Microsoft.ILP.UserService.Models;

namespace Microsoft.ILP.UserService.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
