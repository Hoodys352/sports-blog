using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsBlogWithAuth.Data;
using SportsBlogWithAuth.Models;

namespace SportsBlogWithAuth.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comment Comment { get; set; }
        public Post Post { get; set; }
        public IList<Comment> Comments { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts.FirstOrDefaultAsync(m => m.PostId == id);
            Comments = await _context.Comments.ToListAsync();

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Comment.PostId = (int)id;
            await _context.Comments.AddAsync(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = id });
        }
    }
}
