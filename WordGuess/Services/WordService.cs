public class WordService {

    private readonly Random _random;
    
    public WordService() {
        _random = new Random();
    }

    public string GetRandomWord() {
        var words = WordSeeder.GetWords();
        int randomIndex = _random.Next(words.Count);
        return words[randomIndex].Value; 
    }
}