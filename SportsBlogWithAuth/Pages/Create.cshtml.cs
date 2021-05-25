using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsBlogWithAuth.Models;
using SportsBlogWithAuth.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SportsBlogWithAuth.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<IdentityUser> _userManager;


        public CreateModel(AppDbContext context, 
            IWebHostEnvironment env, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        [BindProperty]
        public Post Post { get; set; }

        [Required(ErrorMessage = "Wymagane jest zdjêcie")]
        [BindProperty]
        public IFormFile Image { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var file = Path.Combine(_env.WebRootPath, "images", Image.FileName);
            Post.ImageName = Path.GetFileName(file);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            //TODO
            //var currentUser = await _userManager.GetUserAsync(User);
            //var UserId = currentUser.Id;
            SetShortContent();
            await _context.Posts.AddAsync(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void SetShortContent()
        {
            if (Post.Content.Length < 250)
            {
                Post.ShortContent = Post.Content;
            }
            else
            {
                Post.ShortContent = Post.Content.Substring(0, 200);
            }
        }
    }
}
