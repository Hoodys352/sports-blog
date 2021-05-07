using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsBlogV2.Data;
using SportsBlogV2.Models;

namespace SportsBlogV2.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comment Comment { get; set; } = new Comment();
        public Post Post { get; set; } = new Post();
        public IList<Comment> Comments { get; set; } = new List<Comment>();
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

        public async Task<IActionResult> OnPostAsync(int Postid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            Comment.PostId = Postid;
            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
