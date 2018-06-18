using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yahon.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public int PostType { get; set; }
        public string PostImage { get; set; }
        public string content { get; set; }
    }
}