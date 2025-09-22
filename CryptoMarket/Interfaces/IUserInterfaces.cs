using CryptoMarket.Models;

namespace CryptoMarket.Interfaces
{
    // Interface Segregation Principle - Separate interfaces for different responsibilities
    
    // User data operations
    public interface IUserRepository
    {
        void AddUser(User user);
        List<User> GetAllUsers();
        List<User> GetUsersByType(string accountType);
        User? GetUserById(Guid userId);
    }

    // User creation operations
    public interface IUserCreationService
    {
        User CreateUser(string name, decimal deposit, string accountType);
    }

    // User display operations
    public interface IUserDisplayService
    {
        void DisplayAllUsers();
        void DisplayUsersByType(string accountType);
    }

    // User validation operations
    public interface IUserValidationService
    {
        bool ValidateName(string name);
        bool ValidateDeposit(decimal deposit);
        bool ValidateAccountType(string accountType);
    }

    // Market operations (already exists, but let's enhance it)
    public interface IMarketRepository
    {
        List<Market> GetAllMarkets();
        Market? GetMarketByCoin(string coin);
        void RefreshMarketData();
    }

    public interface IMarketDisplayService
    {
        void DisplayMarkets();
    }
}
