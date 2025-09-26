using Marketplace.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Services
{
    public class MarketplaceDbContext : DbContext // Fix for CS0311: Ensure MarketplaceDbContext inherits from Microsoft.EntityFrameworkCore.DbContext  
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options)
        {
        }

        public required DbSet<MarketplaceItem> MarketplaceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketplaceItem>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
