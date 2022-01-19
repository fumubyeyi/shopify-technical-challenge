using System.ComponentModel.DataAnnotations;

namespace ShopifyTechnicalChallenge.Models
{
    /// <summary>
    /// Inventory entity
    /// </summary>
    public class Inventory
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }

        public string Description { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public int? Quantity { get; set; }

       
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
   
}
