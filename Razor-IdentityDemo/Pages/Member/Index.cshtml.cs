using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_IdentityDemo.Pages.Member
{
    public class IndexModel : PageModel
    {
		private readonly SignInManager<IdentityUser> signInManager;

        public string? Username { get; set; }

        public IndexModel(SignInManager<IdentityUser> signInManager)
        {
			this.signInManager = signInManager;
		}
        public async Task OnGet()
        {
			IdentityUser? user = await signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                Username = user.UserName;
            }
		}
    }
}
