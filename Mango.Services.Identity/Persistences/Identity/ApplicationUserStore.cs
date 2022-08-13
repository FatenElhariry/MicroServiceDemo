using Mango.Services.Identity.Persistences.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.Identity.Persistences.Identity
{
    public class ApplicationUserStore : IApplicationUserStore
    {


        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserStore(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ApplicationUser AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser FindByExternalProvider(string provider, string userId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser FindBySubjectId(string subjectId)
        {
            return null;
        }

        public ApplicationUser FindByUsername(string username)
        {
            return _userManager.FindByNameAsync(username).Result;
        }

        public bool ValidateCredentials(string username, string password)
        {
            var user = FindByUsername(username);
            if (user == null)
                return false;

            return _signInManager.CheckPasswordSignInAsync(user, password, false).Result.Succeeded;
        }

        public async Task<bool> CreateUserAsync(ApplicationUser user, string passwod)
        {
            return _userManager.CreateAsync(user, passwod).Result.Succeeded;

        }

        public async Task<bool> AssignRoleToUser(ApplicationUser user, string roleName)
        {
            CheckRole(roleName);
            await _userManager.AddToRoleAsync(user, roleName);
            return true;
        }
        private async Task<string> CheckRole(string roleName)
        {
            if (_roleManager.RoleExistsAsync(roleName).Result)
                return roleName;

            var userRole = new IdentityRole
            {
                Name = roleName,
                NormalizedName = roleName,

            };
            await _roleManager.CreateAsync(userRole);
            return roleName;
        }
    }
}
