using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_IdentityDemo.Pages
{
	[AllowAnonymous]
	public class IndexModel : PageModel
	{
		private readonly SignInManager<IdentityUser> signInManager;

		public IndexModel(SignInManager<IdentityUser> signInManager)
        {
			this.signInManager = signInManager;
		}

        public void OnGet()
		{

		}
	}
}