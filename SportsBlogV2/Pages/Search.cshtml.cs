using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsBlogV2.Models;

namespace SportsBlogV2.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Input SearchResult { get; set; }
        public void OnGet()
        {

        }
    }
}
