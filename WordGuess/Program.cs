class WordGuess 
{
    static void Main() 
    {
        var gameService = new GameService();
        var displayService = new DisplayService();
        
        displayService.ShowWelcome();
        
        var gameState = gameService.StartNewGame();
        
        // Debug: Show the word (remove this line later)
        displayService.ShowDebugInfo(gameState.Word);
        
        while (!gameState.IsGameOver) 
        {
            displayService.ShowWordProgress(gameState);
            displayService.ShowAttemptsLeft(gameState);
            displayService.ShowGuessedLetters(gameState);
            
            var inputValidator = new InputValidationService();
            char userGuess = inputValidator.GetValidLetter(gameState.GuessedLetters);
            bool isCorrect = gameService.ProcessGuess(gameState, userGuess);
            
            displayService.ShowFeedback(isCorrect);
            Console.WriteLine();
        }
        
        // Show final result
        if (gameState.IsWon) 
        {
            displayService.ShowWinMessage(gameState.Word);
        } 
        else 
        {
            displayService.ShowLoseMessage(gameState.Word);
        }
    }
}