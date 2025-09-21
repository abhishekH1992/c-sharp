class Ecommerce {
    static void Main() {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine("Welcome to Ecommerce Shop!");
        Console.WriteLine(new string('-', 32));

        var catelogService = new CatelogService();
        var cartService = new CartService();
        var orderService = new OrderService();
        bool running = true;

        while (running) {
            DisplayService.DisplayMessages();
            Console.Write("Enter your choice (0-6): ");
            
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) {
                Console.WriteLine("Please enter a valid option.");
                continue;
            }
            
            if (!int.TryParse(input, out int option)) {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch(option) {
                case 0:
                    Console.WriteLine("Thank you for shopping! Goodbye!");
                    running = false;
                    break;
                    
                case 1:
                    catelogService.ShowAllCategories();
                    Console.Write("\nEnter Category ID to view products (or 0 to go back): ");
                    
                    if (int.TryParse(Console.ReadLine(), out int categoryId)) {
                        if (categoryId == 0) {
                            Console.WriteLine("Returning to main menu...");
                        } else {
                            catelogService.ShowProductsByCategory(categoryId);
                            Console.Write("\nPress 0 to go back to main menu: ");
                            
                            if (int.TryParse(Console.ReadLine(), out int backFromProducts)) {
                                if (backFromProducts == 0) {
                                    Console.WriteLine("Returning to main menu...");
                                } else {
                                    Console.WriteLine("Invalid option. Returning to main menu...");
                                }
                            } else {
                                Console.WriteLine("Invalid input. Returning to main menu...");
                            }
                        }
                    } else {
                        Console.WriteLine("Invalid category ID.");
                    }
                    break;
                    
                case 2:
                    catelogService.ShowAllProducts();
                    Console.Write("\nPress 0 to go back to main menu: ");
                    
                    if (int.TryParse(Console.ReadLine(), out int backOption)) {
                        if (backOption == 0) {
                            Console.WriteLine("Returning to main menu...");
                        } else {
                            Console.WriteLine("Invalid option. Returning to main menu...");
                        }
                    } else {
                        Console.WriteLine("Invalid input. Returning to main menu...");
                    }
                    break;
                    
                case 3:
                    cartService.ShowCartMenu(catelogService, orderService);
                    break;
                    
                case 4:
                    cartService.AddToCartUI(catelogService);
                    break;
                    
                case 5:
                    cartService.UpdateCartItemUI();
                    break;
                    
                case 6:
                    orderService.ShowOrderHistory();
                    Console.Write("\nPress 0 to go back to main menu: ");
                    
                    if (int.TryParse(Console.ReadLine(), out int orderBackOption)) {
                        if (orderBackOption == 0) {
                            Console.WriteLine("Returning to main menu...");
                        } else {
                            Console.WriteLine("Invalid option. Returning to main menu...");
                        }
                    } else {
                        Console.WriteLine("Invalid input. Returning to main menu...");
                    }
                    break;
                    
                default:
                    Console.WriteLine("Invalid option. Please choose 0-6.");
                    break;
            }
            
            if (running) {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}