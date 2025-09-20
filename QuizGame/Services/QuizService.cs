public class QuizService
{
    private readonly InputValidationService _inputValidator;
    private readonly ScoringService _scoringService;
    
    public QuizService()
    {
        _inputValidator = new InputValidationService();
        _scoringService = new ScoringService();
    }
    
    public void StartQuiz()
    {
        Console.WriteLine("Starting Quiz...");
        Console.WriteLine("Questions are randomized for each attempt!");
        
        // Get questions and shuffle them
        var questions = QuestionsSeed.GetQuestions().Shuffle();
        int score = 0;
        
        // Loop through each question
        for (int i = 0; i < questions.Count; i++)
        {
            var question = questions[i];
            
            // Display question
            Console.WriteLine($"\nQuestion {i + 1}: {question.Text}");
            Console.WriteLine($"A) {question.OptionA}");
            Console.WriteLine($"B) {question.OptionB}");
            Console.WriteLine($"C) {question.OptionC}");
            Console.WriteLine($"D) {question.OptionD}");
            
            // Get validated user input
            char userAnswer = _inputValidator.GetValidAnswer();
            
            // Check if correct
            if (userAnswer == question.CorrectAnswer)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect! The correct answer was {question.CorrectAnswer}");
            }
        }
        
        // Show final score with detailed summary
        _scoringService.DisplayScoreSummary(score, questions.Count);
    }
}
