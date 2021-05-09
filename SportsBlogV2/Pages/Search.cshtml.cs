using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsBlogV2.Data;
using SportsBlogV2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBlogV2.Pages
{
    public class SearchModel : PageModel
    {
        public readonly AppDbContext _context;

        public IList<Post> Posts { get; set; } = new List<Post>();

        public SearchModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await GetPosts();
            return Page();
        }

        public async Task OnPostAsync()
        {
            
        }

        public async Task GetPosts()
        {
            Posts = await _context.Posts.ToListAsync();
        }
    }
}
