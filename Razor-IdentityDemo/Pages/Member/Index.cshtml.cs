using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_IdentityDemo.Pages.Member
{
    public class IndexModel : PageModel
    {
		private readonly SignInManager<IdentityUser> signInManager;

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }

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

        // IMplementera logga ut

        public async Task<IActionResult> OnPost()
        {
            await signInManager.SignOutAsync();

            return RedirectToPage("/Index");
        }
    }
}
