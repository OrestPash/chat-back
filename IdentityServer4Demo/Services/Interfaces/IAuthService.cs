using IdentityServer4Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4Demo.Services.Interfaces
{
    public interface IAuthService
    {
        Task<SignupResult> RegisterUserAsync(SignupForm model);
        Task<List<UserVM>> GetUsersAsync();
    }
}
