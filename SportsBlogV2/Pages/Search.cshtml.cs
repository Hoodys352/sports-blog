using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsBlogV2.Data;
using SportsBlogV2.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBlogV2.Pages
{
    public class SearchModel : PageModel
    {
        public readonly AppDbContext _context;
        public SearchModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Input Input { get; set; }
        public IList<Post> Posts { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (InputValidationResult(Input))
            {
                Posts = await _context.Posts.Where(p => p.Title == Input.Search).ToListAsync();
                switch (Posts.Count)
                {
                    case 0:
                        return RedirectToPage("SearchResult", new {  });
                    default:
                        return RedirectToPage("SearchResult", new { title = Input.Search.Trim() }); ;
                }
            }
            return Page();
        }

        private bool InputValidationResult(Input input)
        {
            input.Search.Trim();
            if(input.Search.Length > 0 && input.Search != null)
            {
                return true;
            }
            return false;
        }
    }
}
