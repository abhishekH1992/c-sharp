public class GameState
{
    public string Word { get; set; } = string.Empty;
    public char[] WordArray { get; set; } = Array.Empty<char>();
    public char[] GuessedChars { get; set; } = Array.Empty<char>();
    public HashSet<char> GuessedLetters { get; set; } = new HashSet<char>();
    public int WrongAttempts { get; set; }
    public int MaxAttempts { get; set; } = 5;
    public bool IsGameOver { get; set; }
    public bool IsWon { get; set; }
    
    public void Initialize(string word)
    {
        Word = word;
        WordArray = word.ToCharArray();
        GuessedChars = new char[WordArray.Length];
        GuessedLetters.Clear();
        WrongAttempts = MaxAttempts;
        IsGameOver = false;
        IsWon = false;
        
        // Initialize with underscores
        for (int i = 0; i < GuessedChars.Length; i++)
        {
            GuessedChars[i] = '_';
        }
    }
    
    public bool IsAllGuessed()
    {
        return !GuessedChars.Contains('_');
    }
    
    public int AttemptsLeft => WrongAttempts;
}
