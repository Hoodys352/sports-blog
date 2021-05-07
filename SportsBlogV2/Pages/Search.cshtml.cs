using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsBlogV2.Data;
using SportsBlogV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBlogV2.Pages
{
    public class SearchModel : PageModel, IGetItems
    {
        public readonly AppDbContext _context;
        public readonly ILogger _logger;

        //[BindProperty]
        //public Input searchInput { get; set; }

        public IList<Post> Posts { get; set; } = new List<Post>();

        public SearchModel(AppDbContext context, ILogger<SearchModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            await GetPosts();
            _logger.LogInformation($"Liczba postów : {Posts.Count}");
        }

        public async void OnPostAsync()
        {
            
        }

        public async Task<IList<Post>> GetPosts()
        {
            Posts = await _context.Posts.ToListAsync();
            return Posts;
        }
    }
}
