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
        private SignInManager<ApplicationUser> _signIn;

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signIn)
        {
            _signIn = signIn;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var result = await _signIn.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, false);

                if (result.Succeeded)
                {
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
