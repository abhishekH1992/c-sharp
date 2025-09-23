using CryptoMarket.Models;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Services.User
{
    public class UserService 
    {
        private readonly IUserCreationService _creationService;
        private readonly IUserDisplayService _displayService;
        private readonly UserInputService _inputService;

        // Constructor injection with abstractions
        public UserService(
            IUserCreationService creationService,
            IUserDisplayService displayService,
            UserInputService inputService)
        {
            _creationService = creationService ?? throw new ArgumentNullException(nameof(creationService));
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public Models.User CreateUser()
        {
            try
            {
                string name = _inputService.GetValidName();
                decimal deposit = _inputService.GetValidDeposit();
                string accountType = _inputService.GetValidAccountType();

                Models.User user = _creationService.CreateUser(name, deposit, accountType);
                
                Console.WriteLine($"{accountType} user created successfully: {user.Name} ({user.AccountType}) - Deposit: ${user.Deposit:N2}");
                
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops something went wrong! {ex.Message}");
                Console.WriteLine("Please try again.");
                return CreateUser(); // Retry
            }
        }

        public void GetUserlist()
        {
            _displayService.DisplayAllUsers();
        }

        public void GetRegularUsers()
        {
            _displayService.DisplayUsersByType("Regular");
        }

        public void GetPremiumUsers()
        {
            _displayService.DisplayUsersByType("Premium");
        }
    }
}