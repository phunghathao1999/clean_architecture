using System;
using System.Linq;
using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages.Cinema
{
    public class Sign_upModel : PageModel
    {
        private readonly IPeopleService _service;

        public Sign_upModel(IPeopleService servie)
        {
            _service = servie;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SignupDTO signup { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int count = _service.GetPeople().Where(m => m.Account.Contains(signup.Account)).Count();
            if (count == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return RedirectToPage("Login");
            }
            


            return RedirectToPage("Index");
        }
    }
}