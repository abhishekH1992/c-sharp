public static class ShuffleExtensions
{
    private static readonly Random _random = new Random();
    
    public static List<T> Shuffle<T>(this List<T> list)
    {
        var shuffledList = new List<T>(list);
        
        for (int i = shuffledList.Count - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(i + 1);
            (shuffledList[i], shuffledList[randomIndex]) = (shuffledList[randomIndex], shuffledList[i]);
        }
        
        return shuffledList;
    }
}
