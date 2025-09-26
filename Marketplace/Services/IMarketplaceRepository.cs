using Marketplace.Models.Entities;

namespace Marketplace.Services
{
    public interface IMarketplaceRepository
    {
        IEnumerable<MarketplaceItem> GetAll();
        MarketplaceItem GetById(int id);
        void Add(MarketplaceItem item);
        void Update(MarketplaceItem item);
        void Delete(int id);
        void Save();
    }
}
