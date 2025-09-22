using CryptoMarket.Interfaces;

namespace CryptoMarket.Services
{
    public class UserInputService
    {
        private readonly IUserValidationService _validationService;

        public UserInputService(IUserValidationService validationService)
        {
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
        }

        public string GetValidName()
        {
            while (true)
            {
                Console.WriteLine("Name: ");
                string? name = Console.ReadLine();
                
                if (_validationService.ValidateName(name))
                {
                    return name!;
                }
                
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            }
        }

        public decimal GetValidDeposit()
        {
            while (true)
            {
                Console.WriteLine("Deposit Amount (Minimum $10,000): ");
                string? depositInput = Console.ReadLine();
                
                if (decimal.TryParse(depositInput, out decimal deposit) && _validationService.ValidateDeposit(deposit))
                {
                    return deposit;
                }
                
                Console.WriteLine("Invalid deposit amount. Please enter an amount of $10,000 or more.");
            }
        }

        public string GetValidAccountType()
        {
            while (true)
            {
                Console.WriteLine("Account Type (Please select correct option):\n"+
                                    "1 - Regular Account (Only Spot wallet access)\n"+
                                    "2 - Premium Account (Spot and Earn access)");
                
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    string accountType = choice switch
                    {
                        1 => "Regular",
                        2 => "Premium",
                        _ => ""
                    };

                    if (_validationService.ValidateAccountType(accountType))
                    {
                        return accountType;
                    }
                }
                
                Console.WriteLine("Please enter correct value (1 or 2)");
            }
        }
    }
}
