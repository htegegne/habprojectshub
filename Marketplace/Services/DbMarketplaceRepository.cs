using Marketplace.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Services
{
    public class DbMarketplaceRepository : IMarketplaceRepository
    {
        private readonly MarketplaceDbContext _context;

        public DbMarketplaceRepository(MarketplaceDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MarketplaceItem> GetAll() => _context.MarketplaceItems.ToList();

        public MarketplaceItem GetById(int id) => _context.MarketplaceItems.Find(id);

        public void Add(MarketplaceItem item) => _context.MarketplaceItems.Add(item);

        public void Update(MarketplaceItem item) => _context.Entry(item).State = EntityState.Modified;

        public void Delete(int id)
        {
            var item = _context.MarketplaceItems.Find(id);
            if (item != null) _context.MarketplaceItems.Remove(item);
        }

        public void Save() => _context.SaveChanges();
    }
}
