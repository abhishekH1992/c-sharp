# Word Guessing Game

A console-based word guessing game (Hangman-style) built with C# that challenges players to guess hidden words letter by letter with professional service-based architecture.

## Features

- **Random Word Selection**: Different word each game from a curated list
- **Letter-by-Letter Guessing**: Guess one character at a time
- **Smart Input Validation**: Prevents duplicate guesses and invalid input
- **Attempt Tracking**: Limited attempts with clear feedback
- **Professional Architecture**: Service-based design with separation of concerns
- **Enhanced UI**: Clear progress display and user-friendly interface

## Project Structure

```
WordGuess/
├── Program.cs                    // Main application entry point
├── Models/
│   ├── Words.cs                  // Word data model
│   └── GameState.cs              // Game state management
├── Services/
│   ├── WordService.cs            // Word selection and randomization
│   ├── GameService.cs            // Core game logic and state management
│   ├── InputValidationService.cs // User input validation
│   └── DisplayService.cs         // UI and display management
└── Data/
    └── WordSeeder.cs             // Static word data provider
```

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio, VS Code, or any C# IDE

### Running the Application

1. **Clone or download** the project
2. **Navigate** to the WordGuess directory
3. **Run** the application:
   ```bash
   dotnet run
   ```

### How to Play

1. **Start the application** - You'll see the welcome message
2. **See the word** displayed as underscores (e.g., `_ _ _ _ _ _ _ _ _ _ _`)
3. **Guess letters** by typing single characters (A-Z)
4. **Track progress** as correct letters are revealed
5. **Win** by guessing all letters before running out of attempts
6. **Lose** if you run out of attempts before completing the word

## Game Rules

- **5 Attempts**: You have 5 wrong guesses before game over
- **Single Letters**: Only guess one letter at a time
- **No Duplicates**: Can't guess the same letter twice
- **Case Insensitive**: Accepts both uppercase and lowercase
- **Letter Only**: Only alphabetic characters are accepted

## Sample Gameplay

```
=== Word Guessing Game ===
Guess the correct word!

Debug - The word is: Programming
Word: _ _ _ _ _ _ _ _ _ _ _ 
Attempts left: 5

Enter one character: P
Correct!
Word: P _ _ _ _ _ _ _ _ _ _ 

Enter one character: R
Correct!
Word: P R _ _ _ _ _ _ _ _ _ 

Enter one character: X
Wrong!
Attempts left: 4
Word: P R _ _ _ _ _ _ _ _ _ 

...continue until win or lose
```

## Technical Details

### Architecture
- **Service-Oriented Design**: Each service has a single responsibility
- **State Management**: GameState model tracks all game data
- **Input Validation**: Comprehensive error handling for user input
- **Separation of Concerns**: UI, logic, and data are properly separated

### Key Components

#### Models
- **Words**: Represents a word with its value
- **GameState**: Manages all game state including word, guesses, attempts

#### Services
- **WordService**: Handles word selection and randomization
- **GameService**: Orchestrates game logic and state updates
- **InputValidationService**: Validates and sanitizes user input
- **DisplayService**: Manages all UI output and formatting

#### Data
- **WordSeeder**: Static class providing sample words

## Game State Management

The `GameState` model tracks:
- **Current Word**: The word being guessed
- **Guessed Characters**: Array showing revealed letters
- **Guessed Letters**: Set of all letters guessed so far
- **Attempts**: Number of wrong attempts remaining
- **Game Status**: Whether game is over and if player won

## Input Validation Features

The application handles:
- **Empty Input**: Prompts for valid input
- **Multiple Characters**: Only accepts single letters
- **Non-Alphabetic**: Only accepts A-Z letters
- **Duplicate Guesses**: Prevents guessing same letter twice
- **Case Handling**: Converts input to uppercase automatically

## Customization

### Adding New Words
1. Open `Data/WordSeeder.cs`
2. Add new `Word` objects to the list
3. Ensure each word has a `Value` property

### Modifying Game Rules
1. Open `Models/GameState.cs`
2. Change `MaxAttempts` property for different difficulty
3. Adjust game logic in `Services/GameService.cs`

### Changing Display Format
1. Open `Services/DisplayService.cs`
2. Modify display methods for different UI styles
3. Customize messages and formatting

## Testing

The application includes robust error handling for:
- **Invalid Characters**: Numbers, symbols, spaces
- **Empty Input**: Blank or whitespace-only responses
- **Duplicate Letters**: Already guessed letters
- **Case Variations**: Both uppercase and lowercase input

## Future Enhancements

Potential improvements for future versions:
- **Word Categories**: Different difficulty levels (Easy/Medium/Hard)
- **Hint System**: Provide clues for difficult words
- **High Score Tracking**: Save best attempts
- **File I/O**: Load words from external files
- **Multiplayer Mode**: Two-player guessing
- **Statistics**: Track win/loss ratios and average attempts

## Learning Outcomes

This project demonstrates:
- **C# Fundamentals**: Classes, methods, properties, generics
- **Object-Oriented Programming**: Encapsulation, separation of concerns
- **Service Architecture**: Dependency injection and modular design
- **State Management**: Centralized game state handling
- **Input Validation**: Comprehensive error handling
- **Collections**: Lists, HashSet, arrays, and LINQ concepts
- **Static Classes**: When and why to use static vs instance classes

## Comparison with QuizGame

Both projects share similar architecture but demonstrate different concepts:

| Feature | QuizGame | WordGuess |
|---------|----------|-----------|
| **Data Type** | Questions (complex) | Words (simple) |
| **Game Logic** | Multiple choice | Letter guessing |
| **State Management** | Simple scoring | Complex game state |
| **Input Validation** | A-D answers | Letter validation |
| **Randomization** | Question order | Word selection |

## Time Spent
- **Total**: 2 hours

---
