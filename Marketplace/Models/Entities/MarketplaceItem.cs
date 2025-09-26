using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models.Entities
{
    public class MarketplaceItem
   
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [Required, MaxLength(50)]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string SellerName { get; set; }

        [Required]
        public string SellerEmail { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}
