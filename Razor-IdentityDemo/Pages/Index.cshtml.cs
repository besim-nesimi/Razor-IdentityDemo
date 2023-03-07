using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_IdentityDemo.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
	{
		private readonly SignInManager<IdentityUser> signInManager;
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public IndexModel(SignInManager<IdentityUser> signInManager)
        {
			this.signInManager = signInManager;
		}

        public void OnGet()
		{

		}

        // LOGGA IN
		public async Task<IActionResult> OnPost()
		{

            if (ModelState.IsValid)
            {
                var signInResult = await signInManager.PasswordSignInAsync(Username, Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToPage("/Member/Index");
                }
            }

            return Page();
        }
	}
}