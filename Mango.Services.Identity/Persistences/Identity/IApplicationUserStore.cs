using Mango.Services.Identity.Persistences.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.Identity.Persistences.Identity
{
    public interface IApplicationUserStore
    {


        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool ValidateCredentials(string username, string password);

        /// <summary>
        /// Finds the user by subject identifier.
        /// </summary>
        /// <param name="subjectId">The subject identifier.</param>
        /// <returns></returns>
        ApplicationUser FindBySubjectId(string subjectId);

        /// <summary>
        /// Finds the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        ApplicationUser FindByUsername(string username);

        /// <summary>
        /// Finds the user by external provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        ApplicationUser FindByExternalProvider(string provider, string userId);

        /// <summary>
        /// Automatically provisions a user.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claims">The claims.</param>
        /// <returns></returns>
        ApplicationUser AutoProvisionUser(string provider, string userId, List<Claim> claims);

        Task<bool> CreateUserAsync(ApplicationUser user, string passwod);

        Task<bool> AssignRoleToUser(ApplicationUser user, string roleName);
    }
}
