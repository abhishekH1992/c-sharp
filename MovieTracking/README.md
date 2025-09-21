# Movie Tracking Application

A C# console application for managing and tracking movies using both List and Dictionary data structures. This project demonstrates object-oriented programming concepts including inheritance, data structures, and LINQ operations.

## Features

### Core Functionality
- Add Movies - Add new movies with name, year, and genre
- Display Movies - View all movies in your collection
- Search Movies - Find movies by name or ID
- Sort Movies - Sort movies by name (ascending/descending)
- Delete Movies - Remove movies from your collection
- Statistics - View collection statistics and insights

### Data Structure Implementations

#### List-Based Implementation (MovieService.cs)
- Simple and straightforward approach
- Good for learning basic concepts
- Suitable for small collections (under 100 movies)

#### Dictionary-Based Implementation (DictionaryMovieService.cs)
- Fast O(1) lookups by ID
- Automatic grouping by genre and year
- Better performance for larger collections
- Advanced features like statistics and bulk operations

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio Code or Visual Studio

### Installation
1. Clone the repository
2. Navigate to the MovieTracking directory
3. Run the application:

```
For List-based implementation:
dotnet run Program.cs

For Dictionary-based implementation:
dotnet run DictionaryProgram.cs
```

## Project Structure

```
MovieTracking/
├── Models/
│   └── Movie.cs                 # Movie data model
├── Services/
│   ├── MovieService.cs          # List-based movie operations
│   └── DictionaryMovieService.cs # Dictionary-based movie operations
├── Utils/
│   └── Helper.cs                # Input validation utilities
├── Program.cs                   # Main program (List-based)
├── DictionaryProgram.cs         # Main program (Dictionary-based)
└── README.md                   # This file
```

## Usage Examples

### Adding a Movie
```
Add Details of Movie
Name: The Matrix
Year: 1999
Genre: Sci-Fi
Movie added successfully! ID: 1
```

### Searching Movies
```
Search Movie by Name
Enter movie name: Matrix
Found 1 movie(s):
ID: 1 | The Matrix (1999) | Genre: Sci-Fi
```

### Viewing Statistics
```
Movie Statistics
Total movies: 5
Total genres: 3
Year range: 1999 - 2023

Top genres:
- Action: 2 movies
- Sci-Fi: 2 movies
- Drama: 1 movies
```

## Available Operations

### List-Based Implementation
- Option 0: Exit
- Option 1: Add New Movie
- Option 2: Movie List
- Option 3: Search by Name
- Option 4: Sort Movies

### Dictionary-Based Implementation
- Option 0: Exit
- Option 1: Add New Movie
- Option 2: Display All Movies
- Option 3: Search by ID
- Option 4: Search by Name
- Option 5: Movies by Genre
- Option 6: Movies by Year
- Option 7: Delete Movie
- Option 8: Statistics

## Architecture

### Inheritance Example
```csharp
public class MovieTracking : MovieService {
    // Inherits all methods from MovieService
    // Can override methods for custom behavior
    // Can add new functionality specific to MovieTracking
}
```

### Data Models
```csharp
public class Movie {
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; } = "Unknown";
}
```

## Performance Comparison

| Operation | List | Dictionary |
|-----------|------|------------|
| Add Movie | O(1) | O(1) |
| Find by ID | O(n) | O(1) |
| Find by Name | O(n) | O(n) |
| Delete by ID | O(n) | O(1) |
| Group by Genre | O(n) | O(1) |
| Memory Usage | Lower | Higher |

## Learning Objectives

This project demonstrates:

### Object-Oriented Programming
- Inheritance - MovieTracking inherits from MovieService
- Encapsulation - Private fields with public methods
- Polymorphism - Method overriding and virtual methods

### Data Structures
- List<T> - Dynamic arrays for ordered collections
- Dictionary<TKey, TValue> - Key-value pairs for fast lookups
- LINQ - Language Integrated Query for data manipulation

### C# Features
- Nullable reference types - string! for non-null strings
- Object initializers - new Movie { Name = "..." }
- Lambda expressions - m => m.Name for LINQ operations
- String interpolation - $"Movie: {movie.Name}"

## Time Spent
- 4 Hrs
