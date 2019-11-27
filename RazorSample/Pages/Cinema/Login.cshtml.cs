using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace RazorSample.Pages.Cinema
{
    public class LoginModel : PageModel
    {
        private readonly IPeopleService _service;

        public LoginModel(IPeopleService servie)
        {
            _service = servie;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoginDTO Login{ get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int count = _service.GetPeople().Where(m => m.Account.Contains(Login.Account) && m.Pass.Contains(Login.Password)).Count();
            if (count == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return RedirectToPage("Login");
            }

            var people = _service.GetPeople();
            people = people.Where(m => m.Account.Contains(Login.Account));


            return RedirectToPage("Index");
        }
    }
}