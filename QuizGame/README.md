# Math Quiz Game

A console-based math quiz application built with C# that tests your mathematical knowledge with randomized questions and professional scoring.

## Features

- **10 Math Questions**: Addition, subtraction, multiplication, division, and exponents
- **Randomized Order**: Questions appear in different order each time
- **Input Validation**: Robust validation for A-D answers with error handling
- **Professional Scoring**: Percentage calculation and grade determination
- **Clean Architecture**: Service-based design with separation of concerns
- **User-Friendly Interface**: Clear menus and formatted results

## Project Structure

```
QuizGame/
├── Program.cs                    // Main application entry point
├── Models/
│   └── Questions.cs              // Question data model
├── Services/
│   ├── QuizService.cs            // Main quiz logic and flow
│   ├── InputValidationService.cs // User input validation
│   ├── ScoringService.cs         // Score calculations and grading
│   └── ShuffleExtensions.cs     // Question randomization utility
└── Data/
    └── QuestionsSeed.cs          // Sample math questions
```

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio, VS Code, or any C# IDE

### Running the Application

1. **Clone or download** the project
2. **Navigate** to the QuizGame directory
3. **Run** the application:
   ```bash
   dotnet run
   ```

### How to Play

1. **Start the application** - You'll see the main menu
2. **Select "1"** to start the quiz
3. **Answer questions** by typing A, B, C, or D
4. **View your results** with score, percentage, and grade
5. **Choose "2"** to exit the application

## 📊 Scoring System

| Percentage | Grade | Description |
|------------|-------|-------------|
| 90%+ | Excellent! 🌟 | Outstanding performance |
| 70-89% | Good! 👍 | Solid understanding |
| 50-69% | Fair! 📚 | Room for improvement |
| <50% | Try Again! 💪 | Keep practicing |

## 🛠️ Technical Details

### Architecture
- **Service-Oriented Design**: Each service has a single responsibility
- **Dependency Injection**: Services are injected into QuizService
- **Extension Methods**: Custom Shuffle() method for list randomization
- **Input Validation**: Comprehensive error handling for user input

### Key Components

#### Models
- **Question**: Represents a quiz question with text, options, and correct answer

#### Services
- **QuizService**: Orchestrates the quiz flow and manages game state
- **InputValidationService**: Validates and sanitizes user input
- **ScoringService**: Calculates scores, percentages, and determines grades
- **ShuffleExtensions**: Provides randomization functionality using Fisher-Yates algorithm

#### Data
- **QuestionsSeed**: Contains 10 sample math questions covering various topics

## 🎮 Sample Questions

The quiz includes questions on:
- **Basic Arithmetic**: Addition, subtraction, multiplication, division
- **Exponents**: Squared numbers
- **Mixed Operations**: Various difficulty levels

Example:
```
Question 1: What is 5 × 3?
A) 12
B) 15
C) 18
D) 20
```

## 🔧 Customization

### Adding New Questions
1. Open `Data/QuestionsSeed.cs`
2. Add new `Question` objects to the list
3. Ensure each question has all required properties

### Modifying Scoring
1. Open `Services/ScoringService.cs`
2. Adjust percentage thresholds in `DetermineGrade()` method
3. Customize grade messages and emojis

### Changing Question Types
1. Modify the `Question` model in `Models/Questions.cs`
2. Update the `QuestionsSeed` data accordingly
3. Adjust validation logic if needed

## Testing

The application includes robust error handling for:
- **Invalid Input**: Non-A/B/C/D characters
- **Empty Input**: Blank or whitespace-only responses
- **Multiple Characters**: More than one character input
- **Case Insensitive**: Accepts both uppercase and lowercase

## Future Enhancements

Potential improvements for future versions:
- **High Score Tracking**: Save best scores to file
- **Question Categories**: Different difficulty levels
- **Timed Mode**: Add time limits for questions
- **File I/O**: Load questions from external files
- **Statistics**: Track multiple attempts and progress

## Learning Outcomes

This project demonstrates:
- **C# Fundamentals**: Classes, methods, properties, generics
- **Object-Oriented Programming**: Encapsulation, separation of concerns
- **Service Architecture**: Dependency injection and modular design
- **Input Validation**: Error handling and user experience
- **Extension Methods**: Custom functionality for existing types
- **Collections**: Lists, generics, and LINQ concepts

## Time Spent
- 3 Hours

---
