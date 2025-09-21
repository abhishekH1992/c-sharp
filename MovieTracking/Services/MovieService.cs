public class MovieService {
    protected List<Movie> MovieData = new List<Movie>();

    public bool AddMovie() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Add Details of Movie");
        Console.WriteLine(new string('-', 32));

        Console.WriteLine("Name: ");
        string name = Console.ReadLine()!;

        Console.WriteLine("Year: ");
        string yearInput = Console.ReadLine()!;

        if (!Helper.ValidateInput(name, yearInput)) {
            return false;
        }

        int year = int.Parse(yearInput);
        
        Movie movie = new Movie { Name = name, Year = year };
        MovieData.Add(movie);

        Console.WriteLine($"Movie added to list {name} - {year}");

        return true;
    }
    
    public void GetAllMovies() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Movie List");
        Console.WriteLine(new string('-', 32));
        
        if (MovieData.Count == 0) {
            Console.WriteLine("No movies found. Add some movies first!");
            return;
        }
        
        for (int i = 0; i < MovieData.Count; i++) {
            Console.WriteLine($"{i + 1}. {MovieData[i].Name} ({MovieData[i].Year})");
        }
        
        Console.WriteLine($"\nTotal movies: {MovieData.Count}");
    }

    public void SearchbyName() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Search Movie by name");
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Type name:");
        string searchKey = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(searchKey)) {
            Console.WriteLine($"No movie found");
        }

        var results =  MovieData.Where(e => e.Name.Trim().ToLower().Contains(searchKey.Trim().ToLower())).ToList();

        if (results.Count > 0) {
            Console.WriteLine($"\nFound {results.Count} movie(s):");
            foreach (var movie in results) {
                Console.WriteLine($"- {movie.Name} ({movie.Year})");
            }
        } else {
            Console.WriteLine("\nNo movies found with that name.");
        }
    }

    public void SortByName() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Sorting by name");
        Console.WriteLine(new string('-', 32));

        Console.WriteLine("Options: \n"+
                            "ASC - Ascending \n"+
                            "DESC - Descending");

        string option = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(option) || (option != "ASC" && option != "DESC")) {
            Console.WriteLine("Invalid Option");
            return;
        }

        var results = option == "ASC" 
                        ? MovieData.OrderBy(m => m.Name).ToList() 
                        : MovieData.OrderByDescending(m => m.Name).ToList();
        if (results.Count > 0) {
            Console.WriteLine($"\nMovies by {option}:");
            foreach (var movie in results) {
                Console.WriteLine($"- {movie.Name} ({movie.Year})");
            }
        } else {
            Console.WriteLine("\nNo movies found with that name.");
        }
    }
}