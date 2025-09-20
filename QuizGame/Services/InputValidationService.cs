public class InputValidationService
{
    public char GetValidAnswer()
    {
        while (true)
        {
            Console.Write("Enter your answer (A-D): ");
            string? input = Console.ReadLine()?.Trim().ToUpper();
            
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter an answer (A, B, C, or D).");
                continue;
            }
            
            if (input.Length != 1)
            {
                Console.WriteLine("Please enter only one letter (A, B, C, or D).");
                continue;
            }
            
            char answer = input[0];
            if (answer == 'A' || answer == 'B' || answer == 'C' || answer == 'D')
            {
                return answer;
            }
            
            Console.WriteLine("Invalid input. Please enter A, B, C, or D.");
        }
    }
}
