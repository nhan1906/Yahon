using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yahon.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        [Required]
        public String ProductTypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}