public class DisplayService
{
    public void ShowWelcome()
    {
        Console.WriteLine("=== Word Guessing Game ===");
        Console.WriteLine("Guess the correct word!");
        Console.WriteLine();
    }
    
    public void ShowWordProgress(GameState gameState)
    {
        Console.Write("Word: ");
        for (int i = 0; i < gameState.GuessedChars.Length; i++)
        {
            Console.Write($"{gameState.GuessedChars[i]} ");
        }
        Console.WriteLine();
    }
    
    public void ShowAttemptsLeft(GameState gameState)
    {
        Console.WriteLine($"Attempts left: {gameState.AttemptsLeft}");
    }
    
    public void ShowGuessedLetters(GameState gameState)
    {
        if (gameState.GuessedLetters.Count > 0)
        {
            Console.Write("Guessed letters: ");
            Console.WriteLine(string.Join(", ", gameState.GuessedLetters));
        }
    }
    
    public void ShowFeedback(bool isCorrect)
    {
        if (isCorrect)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
    }
    
    public void ShowWinMessage(string word)
    {
        Console.WriteLine("Congratulations! You guessed the word correctly!");
        Console.WriteLine($"The word was: {word}");
    }
    
    public void ShowLoseMessage(string word)
    {
        Console.WriteLine("Game Over! You ran out of attempts.");
        Console.WriteLine($"The word was: {word}");
    }
    
    public void ShowDebugInfo(string word)
    {
        Console.WriteLine($"Debug - The word is: {word}");
    }
}
