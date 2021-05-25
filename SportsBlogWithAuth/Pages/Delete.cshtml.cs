using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsBlogWithAuth.Models;
using SportsBlogWithAuth.Data;
using Microsoft.AspNetCore.Authorization;

namespace SportsBlogWithAuth.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        public readonly AppDbContext _context;
        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null) { return NotFound(); }

            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
