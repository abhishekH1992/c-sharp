namespace CryptoMarket.Models
{
    public class Market 
    {
        private readonly string _coin;
        private readonly decimal _maxSupply;
        private decimal _currentPrice;

        // Constructor with validation
        public Market(string coin, decimal maxSupply, decimal currentPrice)
        {
            if (string.IsNullOrWhiteSpace(coin))
                throw new ArgumentException("Coin cannot be null or empty", nameof(coin));
            if (maxSupply <= 0)
                throw new ArgumentException("Max supply must be positive", nameof(maxSupply));
            if (currentPrice <= 0)
                throw new ArgumentException("Current price must be positive", nameof(currentPrice));

            _coin = coin;
            _maxSupply = maxSupply;
            _currentPrice = currentPrice;
        }

        // ENCAPSULATION - Read-only properties
        public string Coin => _coin;
        public decimal MaxSupply => _maxSupply;
        public decimal CurrentPrice => _currentPrice;

        // Method to update price (for market fluctuations)
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be positive", nameof(newPrice));
            _currentPrice = newPrice;
        }

        // Method to get market info
        public string GetMarketInfo()
        {
            return $"Spot Market: {_coin} - Price: ${_currentPrice:N2} - Supply: {_maxSupply:N0}";
        }

        // Method to calculate trading fee (Spot markets typically have 0.1% fee)
        public decimal GetTradingFee()
        {
            return 0.1m; // 0.1% fee for spot trading
        }
    }
}