using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBlogV2.Models
{
    public class Post
    {
        public int PostId { get; set; }
        
        [Required(ErrorMessage = "Tytuł jest wymagany - min. 1 litera ")]
        [StringLength(50, MinimumLength = 1)]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Treść jest wymagana - min. 1 litera")]
        [MinLength(1)]
        public string Content { get; set; }
        public string ShortContent { get; set; }

        [Required(ErrorMessage = "Podaj datę")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public string ImageName
        {
            get; set;
        } //image is saved on server, only imagename is added to database

        [Required(ErrorMessage = "Wybierz tag")]
        public ETag ETag { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
