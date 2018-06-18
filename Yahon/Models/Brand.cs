using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Yahon.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public String BrandName { get; set; }
        [Required]
        public String BrandImage { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

}