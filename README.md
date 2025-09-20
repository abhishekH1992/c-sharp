# Progressive Project Path for Learning C#

This repository contains a series of **hands-on C# projects** designed to help you quickly learn and practice all the major concepts of the language.  
Each project builds on the previous one, covering topics step by step.

---

## Project List

### 1. Unit Converter (Fundamentals + Control Flow)
**Concepts:** Data types, variables, operators, loops, `if/switch`, methods, exception handling.  
**Example:** Convert Celsius ↔ Fahrenheit, km ↔ miles.  

---

### 2. Quiz Game (Control Flow + Methods + Exceptions)
**Concepts:** Arrays, loops, randomization, `try/catch`, string handling.  
**Example:** Console-based multiple-choice quiz with scoring.  

---

### 3. Word Guessing Game (Service Architecture + State Management)
**Concepts:** Service-based architecture, state management, input validation, collections.  
**Example:** Hangman-style word guessing game with professional architecture.  

---

### 4. Employee Manager (OOP Basics)
**Concepts:** Classes, objects, constructors, properties, access modifiers.  
**Example:** Add/list/search employees in memory.  

---

### 5. Shape Drawer (OOP Advanced: Inheritance + Interfaces)
**Concepts:** Abstract classes, virtual/override, interfaces, polymorphism.  
**Example:** Base `Shape` → `Circle`, `Rectangle`, `Triangle`, calculate area/perimeter.  

---

### 6. Inventory Tracker (Collections + LINQ)
**Concepts:** `List<T>`, `Dictionary<TKey,TValue>`, LINQ queries (`Where`, `Select`, `OrderBy`, `GroupBy`).  
**Example:** Manage products (add, update, remove), search and filter with LINQ.  

---

### 7. Movie Explorer (LINQ + Lambda Expressions)
**Concepts:** LINQ query syntax & method syntax, lambdas, anonymous types.  
**Example:** Load in-memory movie list → filter by genre/year, sort, group by director.  

---

### 8. Download Manager Simulator (Delegates + Events + Async)
**Concepts:** Delegates, events, `async/await`, tasks, cancellation tokens.  
**Example:** Simulate file downloads with progress events and async methods.  

---

### 9. CSV Contact Book (File I/O + Exception Handling)
**Concepts:** `StreamReader`, `StreamWriter`, `try/catch`, `IDisposable`.  
**Example:** Save/load contacts from CSV file, search and edit contacts.  

---

### 10. Mini Validator (Attributes + Reflection)
**Concepts:** Custom attributes, reflection, validation logic.  
**Example:** `[Required]` and `[Range]` attributes on `User` class, validate input dynamically.  

---

### 11. Todo API (ASP.NET Core Basics + .NET Ecosystem)
**Concepts:** ASP.NET Core minimal API, dependency injection, layered structure.  
**Example:** Simple CRUD API for todo items (`GET/POST/PUT/DELETE`).  

---

## Coverage Map

- **Fundamentals** → Unit Converter  
- **Control Flow** → Quiz Game  
- **Methods & Exceptions** → Unit Converter / Quiz Game  
- **Service Architecture** → Word Guessing Game  
- **State Management** → Word Guessing Game  
- **OOP Basics** → Employee Manager  
- **OOP Advanced** → Shape Drawer  
- **Collections** → Inventory Tracker  
- **LINQ & Lambdas** → Inventory Tracker / Movie Explorer  
- **Delegates & Events + Async** → Download Manager Simulator  
- **File I/O** → CSV Contact Book  
- **Attributes & Reflection** → Mini Validator  
- **ASP.NET Core & .NET Ecosystem** → Todo API  

---

## ⚡ How to Use
1. Clone this repo or create a folder for each project.  
2. Open in **Cursor** (or VS Code with the C# extension).  
3. Run each project with:
   ```bash
   dotnet run
