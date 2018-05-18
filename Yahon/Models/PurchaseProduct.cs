using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yahon.Models
{
    public class PurchaseProduct
    {
        [Key, Column(Order = 0)] public int ProductID { get; set; }
        [Key, Column(Order = 1)] public int PurchaseID { get; set; }
        
        public int quantity;
    }
}