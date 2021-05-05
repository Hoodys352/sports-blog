using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsBlogV2.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortContent { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        public string ImageName { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
