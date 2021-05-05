using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBlogV2.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
