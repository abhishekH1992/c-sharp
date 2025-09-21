public class MovieTracking {
    static void Main() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Welcome to Movie Dictionary");
        Console.WriteLine(new string('-', 32));

        bool isRunning = true;

        var movieService = new MovieService();

        while(isRunning) {
            Console.WriteLine("Options: \n"+
                            "0 - Exit \n"+
                            "1 - Add New Movie \n"+
                            "2 - Movie List \n"+
                            "3 - Search by name \n"+
                            "4 - Sort by name");
            
            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine()!, out int option);
            
            switch(option) {
                case 0:
                    Console.WriteLine(new string('-', 32));
                    Console.WriteLine("Thank you");
                    Console.WriteLine(new string('-', 32));
                    isRunning = false;
                    break;
                case 1:
                    movieService.AddMovie();
                    break;
                case 2:
                    movieService.GetAllMovies();
                    break;
                case 3:
                    movieService.SearchbyName();
                    break;
                case 4:
                    movieService.SortByName();
                    break;
                default:
                    Console.WriteLine("Please select option between 0-2.");
                    break;
            }
            Console.WriteLine();
        }
    }
}