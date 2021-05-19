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

        public ETag ETag { get; set; }

        public IList<Post> Posts { get; set; }
        public string Title { get; set; }

        public async Task OnGet(string title, string tag)
        {
            if(title != null)
            {
                Title = Uri.UnescapeDataString(title);
                Posts = await _context.Posts.Where(p => p.Title == Title).ToListAsync();
            }
            else if(title == null && tag != null)
            {
                switch(tag)
                {
                    case "Football":
                        ETag = ETag.Football;
                        break;
                    case "Baseball":
                        ETag = ETag.Baseball;
                        break;
                    case "Handball":
                        ETag = ETag.Handball;
                        break;
                    case "Volleyball":
                        ETag = ETag.Volleyball;
                        break;
                    case "Hockey":
                        ETag = ETag.Hockey;
                        break;
                }
                Posts = await _context.Posts.Where(p => p.ETag == ETag).ToListAsync();
            }
        }
    }
}
