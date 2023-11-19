using Application.Common.Interfaces;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ErrorOr<Guid>> CreateUserAsync(Guid id, string userName, string password)
        {
            var user = new ApplicationUser
            {
                Id = id.ToString(),
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {
                return id;
            }

            return result.Errors.Select(e => Error.Failure(e.Code, e.Description)).ToList();
        }
    }
}
