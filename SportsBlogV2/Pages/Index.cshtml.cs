using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsBlogV2.Data;
using SportsBlogV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBlogV2.Pages
{
    public class IndexModel : PageModel, IGetItems
    {
        public readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Post> Posts { get; set; }

        public async Task<IList<Post>> GetPosts()
        {
            Posts = await _context.Posts.ToListAsync();
            return Posts;
        }

        public async Task OnGetAsync()
        {
            await GetPosts();
        }
    }
}
