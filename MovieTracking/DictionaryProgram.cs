public class DictionaryMovieTracking {
    static void Main() {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Welcome to Dictionary Movie Tracker");
        Console.WriteLine(new string('-', 40));

        bool isRunning = true;
        var movieService = new DictionaryMovieService();

        while(isRunning) {
            Console.WriteLine("Options: \n"+
                            "0 - Exit \n"+
                            "1 - Add New Movie \n"+
                            "2 - Display All Movies \n"+
                            "3 - Search by ID \n"+
                            "4 - Search by Name \n"+
                            "5 - Movies by Genre \n"+
                            "6 - Movies by Year \n"+
                            "7 - Delete Movie \n"+
                            "8 - Statistics");
            
            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine()!, out int option);
            
            switch(option) {
                case 0:
                    Console.WriteLine(new string('-', 32));
                    Console.WriteLine("Thank you for using Dictionary Movie Tracker!");
                    Console.WriteLine(new string('-', 32));
                    isRunning = false;
                    break;
                case 1:
                    movieService.AddMovie();
                    break;
                case 2:
                    movieService.DisplayAllMovies();
                    break;
                case 3:
                    movieService.SearchById();
                    break;
                case 4:
                    movieService.SearchByName();
                    break;
                case 5:
                    movieService.GetMoviesByGenre();
                    break;
                case 6:
                    movieService.GetMoviesByYear();
                    break;
                case 7:
                    movieService.DeleteMovie();
                    break;
                case 8:
                    movieService.GetStatistics();
                    break;
                default:
                    Console.WriteLine("Please select option between 0-8.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
