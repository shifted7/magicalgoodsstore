using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Account
{
    public class LoginModel : PageModel
    {
        /// <summary>
        /// uses dependency injection to bring in the signinmanager library from Identity
        /// </summary>
        private SignInManager<ApplicationUser> _signIn;
        private UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public LoginViewModel Input { get; set; }

        /// <summary>
        /// brings in the application model into the signinmanager library 
        /// </summary>
        /// <param name="signIn"></param>
        public LoginModel(SignInManager<ApplicationUser> signIn, UserManager<ApplicationUser> userManager)
        {
            _signIn = signIn;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// When user tries to login, this method uses the SignInManger to help the user sign in, if it succeeds, the user will be redirected to the home page, if not, there will be an error the user will see that there was an "invalid login attempt"
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var result = await _signIn.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, false);

                if (result.Succeeded)
                {
                    ApplicationUser user = await _userManager.FindByEmailAsync(Input.Email);
                   
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToPage("/Admin/Index");
                    }

                    return RedirectToPage("/Shop/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Attempt");
                    return Page();
                }
            }
            return Page();
        }

        /// <summary>
        /// properties needed for the login page, just need the email and the password
        /// </summary>
        public class LoginViewModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        };
    }
}
