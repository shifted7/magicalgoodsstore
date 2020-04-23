using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MagicalGoods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public RegisterInput UserData { get; set; }

        public RegisterModel(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signIn)
        {
            _userManager = usermanager;
            _signInManager = signIn;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // creates new user if model state valid
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserData.FirstName,
                    LastName = UserData.LastName,
                    Email = UserData.Email,
                    UserName = UserData.Email
                };

                //grabs the user and creates the account using Identity
                var result = await _userManager.CreateAsync(user, UserData.Password);

                // If successed, this will sign in the user
                if (result.Succeeded)
                {
                    Claim fullName = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    await _userManager.AddClaimAsync(user, fullName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // loads the errors and sends to view page.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }

        public class RegisterInput
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "{0} should be a minimum of {2} characters and maximum {1} characters", MinimumLength = 5)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Confirm Password")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match, please try again, muggle.")]
            public string ConfirmPassword { get; set; }
        }
    }
}
