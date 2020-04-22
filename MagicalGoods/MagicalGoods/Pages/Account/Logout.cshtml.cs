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

        // bring in the SigninManager Library
        private SignInManager<ApplicationUser> _signIn;

        public LogoutModel(SignInManager<ApplicationUser> signIn)
        {
            _signIn = signIn;
        }
        public void OnGet()
        {
        }

        // when user signs out, the user will be redirected to the homepage
        public async Task<IActionResult> OnPost()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
