using System;
using System.ComponentModel.DataAnnotations;

namespace ShopifyTechnicalChallenge.Models
{
    /// <summary>
    /// Inventory entity
    /// </summary>
    public class InventoryModel
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }
    }

    
}
