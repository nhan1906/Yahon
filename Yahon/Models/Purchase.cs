using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yahon.Models
{
    public class Purchase
    {
        [Key, ForeignKey("PurchaseProduct")]
        public int PurchaseID { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        
        public Customer Customer { get; set; }
        public ICollection<PurchaseProduct> PurchaseProduct { get; set; }
    }
}