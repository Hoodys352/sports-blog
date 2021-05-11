using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsBlogV2.Data;
using SportsBlogV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBlogV2.Pages
{
    public class IndexModel : PageModel
    {
        public readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Post> Posts { get; set; }

        public async Task OnGetAsync()
        {
            Posts = await _context.Posts.ToListAsync();
        }
    }
}
