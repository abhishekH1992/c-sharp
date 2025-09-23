namespace CryptoMarket.Services.Display
{
    public class DisplayService {
        public int MainMenu() {
            Console.WriteLine("\n");
            Console.WriteLine(new string('-', 75));
            Console.WriteLine("Select options from below: ");
            Console.WriteLine(new string('-', 75));

            Console.WriteLine("100 - Market \n"+
                                "101 - Get List of all wallets\n"+
                                "1 - To add new user\n"+
                                "2 - Get List of all users\n"+
                                "3 - Get List of all regular users\n"+
                                "4 - Get List of all premium users\n"+
                                "0 - Exit");

            string? userInput = Console.ReadLine();

            if(int.TryParse(userInput, out int option)) {
                return option;
            }
            
            return -1;
        }
    }
}