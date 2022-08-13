using IdentityModel;
using Mango.Services.Identity.Models;
using Mango.Services.Identity.Persistences;
using Mango.Services.Identity.Persistences.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            if ( _roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else
                return;

            ApplicationUser admin = new ApplicationUser()
            {
                FirstName = "Faten",
                LastName = "Elhariry",
                Email = "aelhariry78@gmail.com",
                EmailConfirmed = true,
                UserName = "aelhariry78@gmail.com",
                PhoneNumber = "01023328252"
            };

            _userManager.CreateAsync(admin, "Admin@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(admin, SD.Admin);

            var cliam01 = _userManager.AddClaimsAsync(admin, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{ admin.FirstName } { admin.LastName }"),
                new Claim(JwtClaimTypes.GivenName, $"{ admin.FirstName }"),
                new Claim(JwtClaimTypes.FamilyName, $"{ admin.LastName}"),
                new Claim(JwtClaimTypes.Role, $"{ SD.Admin }"),
            }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                FirstName = "Faten",
                LastName = "Elhariry",
                Email = "aelhariry78@yahoo.com",
                EmailConfirmed = true,
                UserName = "aelhariry78@yahoo.com",
                PhoneNumber = "01023328252"
            };

            _userManager.CreateAsync(admin, "Admin@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(admin, SD.Admin);

            var cliam02 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{ customerUser.FirstName } { customerUser.LastName }"),
                new Claim(JwtClaimTypes.GivenName, $"{ customerUser.FirstName }"),
                new Claim(JwtClaimTypes.FamilyName, $"{ customerUser.LastName}"),
                new Claim(JwtClaimTypes.Role, $"{ SD.Customer }"),
            }).Result;


        }
    }
}
