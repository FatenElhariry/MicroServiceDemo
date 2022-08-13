using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mango.Services.Identity.Pages.Login.ViewModel;

namespace Mango.Services.Identity.Pages.Account.Register
{
    public class InputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public string RoleName { get; set; }
        public bool AllowRemmemberLogin { get; set; } = true;
        public bool EnableLocalLogin { get; set; } = true;
        public List<ExternalProvider> ExternalProviders { get; set; }
        public bool AllowRememberLogin { get; set; }

    }
}
