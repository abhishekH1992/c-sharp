public class DictionaryMovieService {
    private Dictionary<int, Movie> moviesById = new Dictionary<int, Movie>();
    private Dictionary<string, List<Movie>> moviesByGenre = new Dictionary<string, List<Movie>>();
    private Dictionary<int, List<Movie>> moviesByYear = new Dictionary<int, List<Movie>>();
    private int nextId = 1;

    public bool AddMovie() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Add Details of Movie");
        Console.WriteLine(new string('-', 32));

        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Year: ");
        string yearInput = Console.ReadLine()!;
        
        Console.Write("Genre: ");
        string genre = Console.ReadLine()!;

        if (!Helper.ValidateInput(name, yearInput) || string.IsNullOrWhiteSpace(genre)) {
            Console.WriteLine("Please enter valid data for all fields.");
            return false;
        }

        int year = int.Parse(yearInput);
        Movie movie = new Movie { 
            Id = nextId++, 
            Name = name, 
            Year = year, 
            Genre = genre 
        };

        // Add to ID dictionary
        moviesById[movie.Id] = movie;

        // Add to genre dictionary
        if (!moviesByGenre.ContainsKey(genre)) {
            moviesByGenre[genre] = new List<Movie>();
        }
        moviesByGenre[genre].Add(movie);

        // Add to year dictionary
        if (!moviesByYear.ContainsKey(year)) {
            moviesByYear[year] = new List<Movie>();
        }
        moviesByYear[year].Add(movie);

        Console.WriteLine($"Movie added successfully! ID: {movie.Id}");
        return true;
    }

    public void DisplayAllMovies() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Movie List");
        Console.WriteLine(new string('-', 32));
        
        if (moviesById.Count == 0) {
            Console.WriteLine("No movies found. Add some movies first!");
            return;
        }
        
        foreach (var movie in moviesById.Values) {
            Console.WriteLine($"ID: {movie.Id} | {movie.Name} ({movie.Year}) | Genre: {movie.Genre}");
        }
        
        Console.WriteLine($"\nTotal movies: {moviesById.Count}");
    }

    public void SearchById() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Search Movie by ID");
        Console.WriteLine(new string('-', 32));
        Console.Write("Enter movie ID: ");
        
        if (int.TryParse(Console.ReadLine(), out int id)) {
            if (moviesById.ContainsKey(id)) {
                var movie = moviesById[id];
                Console.WriteLine($"\nFound movie:");
                Console.WriteLine($"ID: {movie.Id}");
                Console.WriteLine($"Name: {movie.Name}");
                Console.WriteLine($"Year: {movie.Year}");
                Console.WriteLine($"Genre: {movie.Genre}");
            } else {
                Console.WriteLine($"No movie found with ID: {id}");
            }
        } else {
            Console.WriteLine("Invalid ID format.");
        }
    }

    public void SearchByName() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Search Movie by Name");
        Console.WriteLine(new string('-', 32));
        Console.Write("Enter movie name: ");
        string searchKey = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(searchKey)) {
            Console.WriteLine("Search key cannot be empty.");
            return;
        }

        var results = moviesById.Values
            .Where(m => m.Name.Trim().ToLower().Contains(searchKey.Trim().ToLower()))
            .ToList();

        if (results.Count > 0) {
            Console.WriteLine($"\nFound {results.Count} movie(s):");
            foreach (var movie in results) {
                Console.WriteLine($"ID: {movie.Id} | {movie.Name} ({movie.Year}) | Genre: {movie.Genre}");
            }
        } else {
            Console.WriteLine("No movies found with that name.");
        }
    }

    public void GetMoviesByGenre() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Movies by Genre");
        Console.WriteLine(new string('-', 32));
        
        if (moviesByGenre.Count == 0) {
            Console.WriteLine("No movies found.");
            return;
        }

        Console.WriteLine("Available genres:");
        foreach (var genre in moviesByGenre.Keys.OrderBy(g => g)) {
            Console.WriteLine($"- {genre} ({moviesByGenre[genre].Count} movies)");
        }

        Console.Write("\nEnter genre to view movies: ");
        string genre = Console.ReadLine()!;

        if (moviesByGenre.ContainsKey(genre)) {
            Console.WriteLine($"\nMovies in '{genre}':");
            foreach (var movie in moviesByGenre[genre]) {
                Console.WriteLine($"ID: {movie.Id} | {movie.Name} ({movie.Year})");
            }
        } else {
            Console.WriteLine($"No movies found in genre: {genre}");
        }
    }

    public void GetMoviesByYear() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Movies by Year");
        Console.WriteLine(new string('-', 32));
        
        if (moviesByYear.Count == 0) {
            Console.WriteLine("No movies found.");
            return;
        }

        Console.WriteLine("Available years:");
        foreach (var year in moviesByYear.Keys.OrderBy(y => y)) {
            Console.WriteLine($"- {year} ({moviesByYear[year].Count} movies)");
        }

        Console.Write("\nEnter year to view movies: ");
        if (int.TryParse(Console.ReadLine(), out int year)) {
            if (moviesByYear.ContainsKey(year)) {
                Console.WriteLine($"\nMovies from {year}:");
                foreach (var movie in moviesByYear[year]) {
                    Console.WriteLine($"ID: {movie.Id} | {movie.Name} | Genre: {movie.Genre}");
                }
            } else {
                Console.WriteLine($"No movies found from year: {year}");
            }
        } else {
            Console.WriteLine("Invalid year format.");
        }
    }

    public void DeleteMovie() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Delete Movie");
        Console.WriteLine(new string('-', 32));
        Console.Write("Enter movie ID to delete: ");
        
        if (int.TryParse(Console.ReadLine(), out int id)) {
            if (moviesById.ContainsKey(id)) {
                var movie = moviesById[id];
                
                // Remove from all dictionaries
                moviesById.Remove(id);
                moviesByGenre[movie.Genre].Remove(movie);
                moviesByYear[movie.Year].Remove(movie);
                
                Console.WriteLine($"Movie '{movie.Name}' deleted successfully!");
            } else {
                Console.WriteLine($"No movie found with ID: {id}");
            }
        } else {
            Console.WriteLine("Invalid ID format.");
        }
    }

    public void GetStatistics() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Movie Statistics");
        Console.WriteLine(new string('-', 32));
        
        Console.WriteLine($"Total movies: {moviesById.Count}");
        Console.WriteLine($"Total genres: {moviesByGenre.Count}");
        Console.WriteLine($"Year range: {moviesByYear.Keys.Min()} - {moviesByYear.Keys.Max()}");
        
        Console.WriteLine("\nTop genres:");
        var topGenres = moviesByGenre
            .OrderByDescending(g => g.Value.Count)
            .Take(3);
            
        foreach (var genre in topGenres) {
            Console.WriteLine($"- {genre.Key}: {genre.Value.Count} movies");
        }
    }
}
