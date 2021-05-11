using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsBlogV2.Data;
using SportsBlogV2.Models;

namespace SportsBlogV2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        [Required(ErrorMessage = "Wymagane jest zdjêcie")]
        [BindProperty]
        public IFormFile Image { get; set; }


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
