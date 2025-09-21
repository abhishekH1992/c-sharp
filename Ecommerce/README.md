# E-commerce System

A comprehensive console-based E-commerce application built with C# that demonstrates object-oriented programming principles, service-based architecture, and real-world business logic.

## Project Overview

This E-commerce system provides a complete shopping experience with product catalog management, shopping cart functionality, and order processing. The application showcases advanced C# concepts including LINQ, collections, service patterns, and data validation.

## Features

### Product Management
- Browse products by category
- View all available products
- Real-time inventory tracking
- Product availability validation

### Shopping Cart
- Add products to cart with quantity validation
- Update item quantities
- Remove items from cart
- View cart contents with formatted display
- Automatic cart closure after order placement

### Order Processing
- Place orders with inventory validation
- Order history tracking
- Order details viewing
- Automatic inventory updates after orders
- Order confirmation system

### User Interface
- Interactive menu system
- Clear navigation with back buttons
- Formatted data display
- Input validation and error handling
- User-friendly confirmation prompts

## Project Structure

```
Ecommerce/
├── Models/
│   ├── Category.cs          # Product category model
│   ├── Product.cs           # Product model with inventory
│   ├── Cart.cs              # Shopping cart model
│   └── Order.cs             # Order model
├── Services/
│   ├── CartService.cs       # Cart operations and UI
│   ├── OrderService.cs      # Order processing and history
│   ├── CatelogService.cs    # Product catalog management
│   └── DisplayService.cs   # Menu display utilities
├── Data/
│   ├── CategorySeeder.cs    # Sample category data
│   └── ProductSeeder.cs     # Sample product data
└── Program.cs               # Main application entry point
```

## Getting Started

### Prerequisites
- .NET 9.0 or later
- Visual Studio or VS Code
- Basic understanding of C# programming

### Installation
1. Clone or download the project
2. Navigate to the Ecommerce directory
3. Run the application:
   ```bash
   dotnet run
   ```

## How to Use

### Main Menu Options
- **0 - Exit**: Close the application
- **1 - Show All Category**: Browse products by category
- **2 - Show All Products**: View all available products
- **3 - View Cart**: Access cart management
- **4 - Add to Cart**: Add products to shopping cart
- **5 - Update Cart Item**: Modify cart item quantities
- **6 - Order History**: View past orders

### Shopping Flow
1. **Browse Products**: Use options 1 or 2 to view available products
2. **Add to Cart**: Select option 4 to add products with desired quantities
3. **Manage Cart**: Use option 3 to view cart and access cart operations
4. **Place Order**: From cart menu, select option 4 to place order
5. **View History**: Use option 6 to view order history

### Cart Management
- **Add Items**: Add new products or update existing quantities
- **Update Quantities**: Modify quantities or remove items (set qty to 0)
- **Remove Items**: Delete specific products from cart
- **Place Order**: Complete purchase and clear cart

## Technical Details

### Object-Oriented Programming Concepts
- **Classes and Objects**: Product, Cart, Order, Category models
- **Encapsulation**: Private fields with public properties
- **Service Pattern**: Separation of business logic into services
- **Dependency Injection**: Services passed as parameters

### Data Management
- **Collections**: List<T> for dynamic data storage
- **LINQ Operations**: FirstOrDefault, Where, Any for data querying
- **Static Data**: Seeder classes for sample data
- **Memory Storage**: In-memory data persistence during session

### Input Validation
- **Type Safety**: TryParse for safe string-to-number conversion
- **Range Validation**: Quantity and ID validation
- **Existence Checks**: Product and category validation
- **Inventory Validation**: Stock availability verification

### Error Handling
- **Graceful Degradation**: Invalid input handling without crashes
- **User Feedback**: Clear error messages and success confirmations
- **Input Reprompting**: Retry mechanisms for invalid inputs
- **Edge Case Handling**: Empty cart, non-existent products

## Key Learning Outcomes

### C# Language Features
- **Properties**: get/set accessors with initialization
- **Constructors**: Object initialization patterns
- **Static Classes**: Utility classes and data providers
- **Extension Methods**: Custom LINQ-like operations
- **Nullable Types**: Safe handling of potentially null values

### Software Architecture
- **Separation of Concerns**: UI, business logic, and data layers
- **Service-Based Design**: Modular, testable components
- **Single Responsibility**: Each class has one clear purpose
- **Dependency Management**: Loose coupling between components

### Business Logic
- **Inventory Management**: Real-time stock tracking
- **Order Processing**: Complete order lifecycle
- **Cart State Management**: Open/closed cart states
- **Data Validation**: Comprehensive input and business rule validation

## Sample Data

The application includes sample data for demonstration:
- **3 Categories**: Electronics, Men's Fashion, Women's Fashion
- **11 Products**: Various items with different quantities
- **Realistic Inventory**: Products with varying stock levels

## Development Notes

### Code Organization
- **Models**: Pure data structures with minimal logic
- **Services**: Business logic and UI operations
- **Data**: Static data providers and seeders
- **Program**: Application orchestration and menu handling

### Best Practices Implemented
- **DRY Principle**: Reusable methods and components
- **Consistent Naming**: Clear, descriptive method and variable names
- **Error Prevention**: Proactive validation and error handling
- **User Experience**: Intuitive navigation and clear feedback

### Extensibility
The architecture supports easy extension for:
- **Database Integration**: Replace in-memory storage with database
- **Payment Processing**: Add payment service integration
- **User Management**: Implement user accounts and authentication
- **Advanced Features**: Wishlist, recommendations, reviews

## Testing

### Manual Testing Scenarios
- **Valid Operations**: Add products, place orders, view history
- **Invalid Inputs**: Non-existent products, invalid quantities
- **Edge Cases**: Empty cart, insufficient inventory
- **Navigation**: Menu flow and back button functionality

### Test Cases Covered
- Product existence validation
- Quantity availability checking
- Cart state management
- Order processing workflow
- Error handling and recovery

## Future Enhancements

### Potential Improvements
- **Database Integration**: Persistent data storage
- **User Authentication**: Login and user management
- **Payment Gateway**: Real payment processing
- **Admin Panel**: Product and order management
- **Reporting**: Sales analytics and reports
- **API Integration**: External service connections

### Advanced Features
- **Search Functionality**: Product search and filtering
- **Recommendations**: AI-powered product suggestions
- **Multi-language Support**: Internationalization
- **Mobile App**: Cross-platform mobile interface
- **Real-time Updates**: Live inventory and order tracking

## Learning Path Integration

This project builds upon concepts from previous projects:
- **QuizGame**: Service architecture and input validation
- **WordGuess**: Game state management and UI patterns
- **EmployeeManager**: CRUD operations and data management

The E-commerce system combines all learned concepts into a comprehensive business application.

## Time Investment

**Development Time**: Approximately 4-5 hours
- **Initial Setup**: 30 minutes
- **Core Models**: 45 minutes
- **Service Implementation**: 2 hours
- **Order Processing**: 1 hour
- **UI and Validation**: 1 hour
- **Testing and Refinement**: 30 minutes

## Conclusion

This E-commerce system demonstrates practical application of C# programming concepts in a real-world business scenario. The project showcases service-based architecture, comprehensive data validation, and user-friendly interface design while maintaining clean, maintainable code structure.

The application serves as an excellent foundation for understanding enterprise-level application development patterns and provides a solid base for further enhancements and real-world implementations.
