public class InputValidationService
{
    public char GetValidLetter(HashSet<char> alreadyGuessed)
    {
        while (true)
        {
            Console.Write("Enter one character: ");
            string? input = Console.ReadLine()?.Trim().ToUpper();
            
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a letter.");
                continue;
            }
            
            if (input.Length != 1)
            {
                Console.WriteLine("Please enter only one character.");
                continue;
            }
            
            char letter = input[0];
            
            if (!char.IsLetter(letter))
            {
                Console.WriteLine("Please enter a valid letter (A-Z).");
                continue;
            }
            
            if (alreadyGuessed.Contains(letter))
            {
                Console.WriteLine($"You already guessed '{letter}'. Try a different letter.");
                continue;
            }
            
            return letter;
        }
    }
}
