using CryptoMarket.Models;
using CryptoMarket.Models.UserTypes;
using CryptoMarket.Interfaces;
using CryptoMarket.Events;

namespace CryptoMarket.Services
{
    public class UserCreationService : IUserCreationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidationService _validationService;
        private readonly IEventPublisher _eventPublisher;

        public UserCreationService(IUserRepository userRepository, IUserValidationService validationService, IEventPublisher eventPublisher)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
        }

        public User CreateUser(string name, decimal deposit, string accountType)
        {
            // Validate inputs
            if (!_validationService.ValidateName(name))
                throw new ArgumentException("Invalid name", nameof(name));
            
            if (!_validationService.ValidateDeposit(deposit))
                throw new ArgumentException("Invalid deposit amount", nameof(deposit));
            
            if (!_validationService.ValidateAccountType(accountType))
                throw new ArgumentException("Invalid account type", nameof(accountType));

            // Create user based on type
            User user = accountType.ToLower() switch
            {
                "regular" => new RegularUser(name, deposit),
                "premium" => new PremiumUser(name, deposit),
                _ => throw new ArgumentException($"Unknown account type: {accountType}")
            };

            // Add to repository
            _userRepository.AddUser(user);
            
            // Publish user created event
            var userCreatedArgs = new UserCreatedEventArgs(user);
            _eventPublisher.PublishUserCreated(userCreatedArgs);
            
            return user;
        }
    }

    // Single Responsibility Principle - Only handles user validation
    public class UserValidationService : IUserValidationService
    {
        public bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public bool ValidateDeposit(decimal deposit)
        {
            return deposit >= 10000;
        }

        public bool ValidateAccountType(string accountType)
        {
            return !string.IsNullOrWhiteSpace(accountType) && 
                   (accountType.Equals("Regular", StringComparison.OrdinalIgnoreCase) ||
                    accountType.Equals("Premium", StringComparison.OrdinalIgnoreCase));
        }
    }

    // Single Responsibility Principle - Only handles user display
    public class UserDisplayService : IUserDisplayService
    {
        private readonly IUserRepository _userRepository;

        public UserDisplayService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void DisplayAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            
            if (users.Count > 0)
            {
                Console.WriteLine($"{"UserId", -40} {"Name", -20} {"AccountType", -13} {"Deposit", -15}");
                Console.WriteLine(new string('-', 90));
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.UserId, -40} {user.Name, -20} {user.AccountType, -13} ${user.Deposit, -14:N2}");
                }
            }
            else
            {
                Console.WriteLine("No users found.");
            }
        }

        public void DisplayUsersByType(string accountType)
        {
            var users = _userRepository.GetUsersByType(accountType);
            
            if (users.Count > 0)
            {
                Console.WriteLine($"{"UserId", -40} {"Name", -20} {"AccountType", -13} {"Deposit", -15}");
                Console.WriteLine(new string('-', 90));
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.UserId, -40} {user.Name, -20} {user.AccountType, -13} ${user.Deposit, -14:N2}");
                }
            }
            else
            {
                Console.WriteLine($"No {accountType.ToLower()} users found.");
            }
        }
    }
}
