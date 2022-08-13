using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        // here you define the scope that the user has access on
        // here you  can define scope for each action from CRUD operation 
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("mango", "Mango Server"),
            new ApiScope("read", "Read your data"),
            new ApiScope("write", "Write your data"),
            new ApiScope("delete", "Delete your data"),
            new ApiScope("update", "Update your data"),
        };

        // client ==> is a piece of software that required tocken from the server 
        /// 1. can use for authonticate the user  
        /// 2. accesses resources 
        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId = "Client",
                ClientSecrets = {  new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "profile" } // profile is  a buildin scope 
            },

            new Client()
            {
                ClientId = "Mango",
                ClientSecrets = {  new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:7031/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:7031/signout-callback-oidc" },
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "mango"
                }
            }

        };
    }
}
