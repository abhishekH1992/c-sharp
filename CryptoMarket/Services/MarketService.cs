using CryptoMarket.Models;
using CryptoMarket.Data;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Services
{
    public class MarketService : IMarketService
    {
        private readonly List<Market> _markets;
        private readonly MarketSeeder _seeder;

        // Constructor injection
        public MarketService(MarketSeeder seeder)
        {
            _seeder = seeder ?? throw new ArgumentNullException(nameof(seeder));
            _markets = MarketSeeder.GetSeedData();
        }

        public List<Market> GetMarkets()
        {
            return _markets.ToList(); // Return copy to prevent external modification
        }

        public Market? GetMarketByCoin(string coin)
        {
            return _markets.FirstOrDefault(m => m.Coin.Equals(coin, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayMarkets()
        {
            // Generate fresh random prices each time market is displayed
            var currentMarkets = MarketSeeder.GetRefreshedData();
            
            if (currentMarkets.Count > 0)
            {
                Console.WriteLine($"{"Coin", -8} {"Max Supply", -15} {"Current Price", -15}");
                Console.WriteLine(new string('-', 40));
                foreach (var market in currentMarkets)
                {
                    Console.WriteLine($"{market.Coin, -8} {market.MaxSupply, -15:N0} ${market.CurrentPrice, -14:N2}");
                }
            }
            else
            {
                Console.WriteLine("No market data available.");
            }
        }

        public void RefreshPrices()
        {
            var newMarkets = MarketSeeder.GetRefreshedData();
            _markets.Clear();
            _markets.AddRange(newMarkets);
            Console.WriteLine("Market prices refreshed!");
        }
    }
}
