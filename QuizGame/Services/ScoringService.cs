public class ScoringService
{
    public double CalculatePercentage(int score, int totalQuestions)
    {
        if (totalQuestions == 0) return 0;
        return Math.Round((double)score / totalQuestions * 100, 1);
    }
    
    public string DetermineGrade(int score, int totalQuestions)
    {
        double percentage = CalculatePercentage(score, totalQuestions);
        
        if (percentage >= 90)
            return "Excellent!";
        else if (percentage >= 70)
            return "Good!";
        else if (percentage >= 50)
            return "Fair!";
        else
            return "Try Again!";
    }
    
    public void DisplayScoreSummary(int score, int totalQuestions)
    {
        double percentage = CalculatePercentage(score, totalQuestions);
        string grade = DetermineGrade(score, totalQuestions);
        
        Console.WriteLine("\n" + new string('=', 40));
        Console.WriteLine("           QUIZ RESULTS");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine($"Score: {score}/{totalQuestions}");
        Console.WriteLine($"Percentage: {percentage}%");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine(new string('=', 40));
    }
}
