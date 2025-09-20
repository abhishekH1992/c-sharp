class QuizGame 
{
    static void Main() 
    {
        bool running = true;
        
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine()!;
            
            switch (choice)
            {
                case "1":
                    var quizService = new QuizService();
                    quizService.StartQuiz();
                    break;
                case "2":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    
    static void ShowMenu()
    {
        Console.WriteLine("\n=== Math Quiz Game ===");
        Console.WriteLine("1. Start Quiz");
        Console.WriteLine("2. Exit");
        Console.Write("Enter your choice (1-2): ");
    }
}