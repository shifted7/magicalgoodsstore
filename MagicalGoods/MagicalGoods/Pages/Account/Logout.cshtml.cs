using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Account
{
    public class LogoutModel : PageModel
    {

        // bring in the SigninManager Library from Identity
        private SignInManager<ApplicationUser> _signIn;

        /// <summary>
        /// brings in the application model into the signinmanager library 
        /// </summary>
        /// <param name="signIn"></param>
        public LogoutModel(SignInManager<ApplicationUser> signIn)
        {
            _signIn = signIn;
        }
        public void OnGet()
        {
        }

        // when user signs out, this method uses the signinmanager to sign out and the user will be redirected to the homepage
        public async Task<IActionResult> OnPost()
        {
            await _signIn.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
