using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsBlogV2.Models
{
    public class Input
    {
        [Required]
        [MinLength(1)]
        public string Search { get; set; }
    }
}
