using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBlogV2.Models
{
    public class Post
    {
        public int PostId { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Title { get; set; }
        
        [Required]
        [MinLength(1)]
        public string Content { get; set; }
        public string ShortContent { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string ImageName
        {
            get; set;
        } //image is saved on server, only imagename is added to database

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
