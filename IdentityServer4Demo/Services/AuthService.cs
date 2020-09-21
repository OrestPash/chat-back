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
            return await _userManager.Users.Select(x=> new UserVM { Id = x.Id, Name = x.UserName})?.ToListAsync();
        }

        public async Task<string> RegisterUserAsync(SignupForm model)
        {
            var res = await _userManager.FindByNameAsync(model.UserName);

            //TODO "User already exist"
            //if (res != null)
            //{
            //     throw new Exception();
            //}

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
            //TODO "Wrong email"
            else
            {
                //throw new Exception();
            }

            await _userManager.CreateAsync(newUser, model.Password);
            return newUser.Id;
        }
    }
}
