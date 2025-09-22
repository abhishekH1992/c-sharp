using CryptoMarket.Models;

namespace CryptoMarket.Interfaces
{
    // Interface Segregation Principle - Single responsibility interface
    public interface IMarketService
    {
        List<Market> GetMarkets();
        Market? GetMarketByCoin(string coin);
        void DisplayMarkets();
        void RefreshPrices();
    }
}
