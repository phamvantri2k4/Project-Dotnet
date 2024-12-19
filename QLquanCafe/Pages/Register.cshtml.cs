using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLquanCafe.Data;
using QLquanCafe.Models;
using static QLquanCafe.Models.User;

namespace QLquanCafe.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly DbContect _context;

        [BindProperty]
        public User Input { get; set; }

        public RegisterModel(DbContect context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Input.Role = UserRole.User;

            _context.Users.Add(Input);
            _context.SaveChanges();

            return RedirectToPage("Login");
        }
    }
}
