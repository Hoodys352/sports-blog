using SportsBlogV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBlogV2.Data
{
    public interface IGetItems
    {
        Task<IList<Post>> GetPosts();
    }
}
