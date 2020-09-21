using IdentityServer4Demo.Models;
using IdentityServer4Demo.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Demo.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserVM>> GetUsersAsync()
        {
            return await _userManager.Users.Select(x => new UserVM { Id = x.Id, Name = x.UserName })?.ToListAsync();
        }

        public async Task<SignupResult> RegisterUserAsync(SignupForm model)
        {
            var newUser = new IdentityUser
            {
                LockoutEnabled = true,
                UserName = model.UserName
            };

            var emailAttr = new EmailAddressAttribute();
            if (emailAttr.IsValid(model.UserName))
            {
                newUser.Email = model.UserName;
            }

            var result = await _userManager.CreateAsync(newUser, model.Password);

            var signupResult = new SignupResult { IsSuccess = result.Succeeded };

            if (!result.Succeeded)
            {
                signupResult.Errors = result.Errors.Select(x => x.Description).ToList();
            }
            else
            {
                signupResult.Id = newUser.Id;
            }

            return signupResult;
        }
    }
}
