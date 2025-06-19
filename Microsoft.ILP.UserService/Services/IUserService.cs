using Microsoft.ILP.UserService.DTOs;
using Microsoft.ILP.UserService.Models;

namespace Microsoft.ILP.UserService.Services
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        UserDto Create(CreateUserDto dto);
        void Update(int id, UpdateUserDto dto);
        void Delete(int id);

        /// <summary>
        /// Validates credentials and returns the matching domain user when found.
        /// </summary>
        /// <param name="email">User email address.</param>
        /// <param name="password">User password.</param>
        /// <returns>The user if credentials are valid; otherwise <c>null</c>.</returns>
        User? Authenticate(string email, string password);
    }
}

