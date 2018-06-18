using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yahon.Models
{
    public class Product
    {
        [Key, ForeignKey("PurchaseProduct")]
        public int ProductId { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public string ProductDetail { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public virtual ICollection<PurchaseProduct> PurchaseProduct { get; set; }
    }
}