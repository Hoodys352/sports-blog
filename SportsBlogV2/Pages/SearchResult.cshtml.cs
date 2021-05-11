using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsBlogV2.Data;
using SportsBlogV2.Models;

namespace SportsBlogV2.Pages
{
    public class SearchResultModel : PageModel
    {
        private readonly AppDbContext _context;
        public SearchResultModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Post> Posts { get; set; }
        public string Title { get; set; }

        public async Task OnGet(string? title)
        {
            Title = Uri.UnescapeDataString(title);
            Posts = await _context.Posts.Where(p => p.Title == Title).ToListAsync();
        }
    }
}
