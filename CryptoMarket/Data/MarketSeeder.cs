using CryptoMarket.Models;

namespace CryptoMarket.Data
{
    public class MarketSeeder {
        private static readonly Random _random = new Random();
        
        // Static method to get initial seed data with fixed prices
        public static List<Market> GetSeedData()
        {
            return new List<Market>
            {
                new Market("BTC", 100m, 110000.00m),
                new Market("XRP", 100000m, 3.50m),
                new Market("ETH", 500m, 4500.00m),
                new Market("BNB", 1000m, 1050.00m)
            };
        }
        
        // Static method to get refreshed data with random prices
        public static List<Market> GetRefreshedData()
        {
            return new List<Market>
            {
                new Market("BTC", 100m, GetRandomPrice(110000.00m, 0.01m)),
                new Market("XRP", 100000m, GetRandomPrice(3.50m, 0.02m)),
                new Market("ETH", 500m, GetRandomPrice(4500.00m, 0.04m)),
                new Market("BNB", 1000m, GetRandomPrice(1050.00m, 0.05m))
            };
        }
        
        private static decimal GetRandomPrice(decimal basePrice, decimal variationPercent)
        {
            // Generate random variation between -variationPercent and +variationPercent
            var variation = (decimal)(_random.NextDouble() * 2 - 1) * variationPercent;
            var newPrice = basePrice * (1 + variation);
            
            // Round to 2 decimal places
            return Math.Round(newPrice, 2);
        }
    }
}