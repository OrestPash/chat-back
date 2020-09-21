using IdentityServer4Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4Demo.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterUserAsync(SignupForm model);
        Task<List<UserVM>> GetUsersAsync();
    }
}
