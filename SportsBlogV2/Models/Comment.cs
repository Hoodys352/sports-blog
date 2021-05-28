using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBlogV2.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        
        [Required(ErrorMessage = "Musisz podać treść komentarza")]
        [StringLength(4000, MinimumLength = 1)]
        [Column("Content", TypeName="NVARCHAR(4000)")]
        public string Content { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
