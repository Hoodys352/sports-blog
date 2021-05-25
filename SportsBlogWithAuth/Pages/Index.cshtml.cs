using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsBlogWithAuth.Models;
using SportsBlogWithAuth.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SportsBlogWithAuth.Pages
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
