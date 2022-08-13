using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Mango.Services.Identity.Models;
using Mango.Services.Identity.Pages.Login;
using Mango.Services.Identity.Persistences.Data.Entities;
using Mango.Services.Identity.Persistences.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Mango.Services.Identity.Pages.Login.ViewModel;

namespace Mango.Services.Identity.Pages.Account.Register
{
    public class RegisterModel : PageModel
    {
        private readonly IApplicationUserStore _users;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IIdentityProviderStore _identityProviderStore;
        private readonly IClientStore _clientStore;

        // public ViewModel View { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public RegisterModel()
        {

        }

        public RegisterModel(IApplicationUserStore users, IIdentityServerInteractionService interaction, IEventService events, IAuthenticationSchemeProvider schemeProvider, IIdentityProviderStore identityProviderStore, IClientStore clientStore)
        {
            _users = users;
            _interaction = interaction;
            _events = events;
            _schemeProvider = schemeProvider;
            _identityProviderStore = identityProviderStore;
            _clientStore = clientStore;
        }

        public async Task<IActionResult> OnGet(string returnUrl)
        {
            var vm = BuildModelAsync(returnUrl).Result;

            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            ViewData["ReturnUrl"] = Input.ReturnUrl;
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    EmailConfirmed = true,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName
                };

                var result = await _users.CreateUserAsync(user, Input.Password);
                if (result)
                {
                    _users.AssignRoleToUser(user, Input.RoleName);

                    //await _userManager.AddClaimsAsync(user, new Claim[]{
                    //        new Claim(JwtClaimTypes.Name, model.Username),
                    //        new Claim(JwtClaimTypes.Email, model.Email),
                    //        new Claim(JwtClaimTypes.FamilyName, model.FirstName),
                    //        new Claim(JwtClaimTypes.GivenName, model.LastName),
                    //        new Claim(JwtClaimTypes.WebSite, "http://"+model.Username+".com"),
                    //        new Claim(JwtClaimTypes.Role,"User") });

                    //var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
                    //var loginresult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: true);
                    //if (loginresult.Succeeded)
                    //{
                    //    var checkuser = await _userManager.FindByNameAsync(model.Username);
                    //    await _events.RaiseAsync(new UserLoginSuccessEvent(checkuser.UserName, checkuser.Id, checkuser.UserName, clientId: context?.Client.ClientId));

                    //    if (context != null)
                    //    {
                    //        if (context.IsNativeClient())
                    //        {
                    //            // The client is native, so this change in how to
                    //            // return the response is for better UX for the end user.
                    //            return this.LoadingPage("Redirect", model.ReturnUrl);
                    //        }

                    //        // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                    //        return Redirect(model.ReturnUrl);
                    //    }

                    //    // request for a local page
                    //    if (Url.IsLocalUrl(model.ReturnUrl))
                    //    {
                    //        return Redirect(model.ReturnUrl);
                    //    }
                    //    else if (string.IsNullOrEmpty(model.ReturnUrl))
                    //    {
                    //        return Redirect("~/");
                    //    }
                    //    else
                    //    {
                    //        // user might have clicked on a malicious link - should be logged
                    //        throw new Exception("invalid return URL");
                    //    }
                    }

                }

                return Page();
        }


        private async Task<InputModel> BuildModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

            List<string> roles = new List<string> { SD.Admin, SD.Customer };

            ViewData.Add("messages", roles);

            if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
            {
                var local = context.IdP == Duende.IdentityServer.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                var vm = new InputModel
                {
                    EnableLocalLogin = local,
                    ReturnUrl = returnUrl,
                    UserName = context?.LoginHint,
                };

                if (!local)
                {
                    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } }.ToList();
                }

                return vm;
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName ?? x.Name,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.Client.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.Client.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new InputModel
            {
                AllowRememberLogin = LoginOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && LoginOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                UserName = context?.LoginHint,
                ExternalProviders = providers.ToList()
            };
        }
    }
}
