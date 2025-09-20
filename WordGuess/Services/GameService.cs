public class GameService
{
    private readonly WordService _wordService;
    private readonly InputValidationService _inputValidator;
    
    public GameService()
    {
        _wordService = new WordService();
        _inputValidator = new InputValidationService();
    }
    
    public GameState StartNewGame()
    {
        string word = _wordService.GetRandomWord();
        var gameState = new GameState();
        gameState.Initialize(word);
        return gameState;
    }
    
    public bool ProcessGuess(GameState gameState, char letter)
    {
        bool found = false;
        
        // Add to guessed letters
        gameState.GuessedLetters.Add(letter);
        
        // Check if letter exists in word
        for (int i = 0; i < gameState.WordArray.Length; i++)
        {
            if (char.ToUpper(letter) == char.ToUpper(gameState.WordArray[i]))
            {
                gameState.GuessedChars[i] = char.ToUpper(gameState.WordArray[i]);
                found = true;
            }
        }
        
        if (!found)
        {
            gameState.WrongAttempts--;
        }
        
        // Check win condition
        if (gameState.IsAllGuessed())
        {
            gameState.IsWon = true;
            gameState.IsGameOver = true;
        }
        // Check lose condition
        else if (gameState.WrongAttempts <= 0)
        {
            gameState.IsGameOver = true;
        }
        
        return found;
    }
}
