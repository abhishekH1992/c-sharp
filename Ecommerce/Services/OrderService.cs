public class OrderService {
    private List<Order> orders = new List<Order>();
    private List<Product> products;
    private int nextOrderId = 1;

    public OrderService() {
        products = ProductSeeder.ProductData();
    }

    public bool PlaceOrder(Cart cart) {
        if (cart.Items.Count == 0) {
            Console.WriteLine("Cannot place order: Cart is empty.");
            return false;
        }

        // Validate all items before placing order
        foreach (var item in cart.Items) {
            if (!IsProductExist(item.ProductId, item.Quantity)) {
                Console.WriteLine($"Cannot place order: Insufficient quantity for Product {item.ProductId}.");
                return false;
            }
        }

        // Create order
        var order = new Order {
            OrderId = nextOrderId++,
            Items = new List<CartItem>(cart.Items),
            CreatedDate = DateTime.Now
        };

        // Update product quantities
        foreach (var item in order.Items) {
            var product = products.FirstOrDefault(p => p.ProductId == item.ProductId);
            if (product != null) {
                product.Quantity -= item.Quantity;
            }
        }

        // Add order to history
        orders.Add(order);

        // Clear cart and close it
        cart.Items.Clear();
        cart.IsCartOpen = false;

        Console.WriteLine($"Order #{order.OrderId} placed successfully!");
        Console.WriteLine($"Order Date: {order.CreatedDate:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Total Items: {order.Items.Count}");
        
        return true;
    }

    public void ShowOrderHistory() {
        Console.WriteLine("\n=== Order History ===");
        if (orders.Count == 0) {
            Console.WriteLine("No orders found.");
            return;
        }

        Console.WriteLine($"{"Order ID",-10} {"Date",-20} {"Items",-10}");
        Console.WriteLine(new string('-', 40));
        
        foreach (var order in orders.OrderByDescending(o => o.CreatedDate)) {
            Console.WriteLine($"{order.OrderId,-10} {order.CreatedDate:yyyy-MM-dd HH:mm} {order.Items.Count,-10}");
        }
        
        Console.WriteLine($"\nTotal Orders: {orders.Count}");
    }

    public void ShowOrderDetails(int orderId) {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null) {
            Console.WriteLine($"Order #{orderId} not found.");
            return;
        }

        Console.WriteLine($"\n=== Order #{orderId} Details ===");
        Console.WriteLine($"Order Date: {order.CreatedDate:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"{"Product ID",-12} {"Quantity",-10}");
        Console.WriteLine(new string('-', 22));
        
        foreach (var item in order.Items) {
            Console.WriteLine($"{item.ProductId,-12} {item.Quantity,-10}");
        }
        
        Console.WriteLine($"\nTotal Items: {order.Items.Count}");
    }

    public void PlaceOrderUI(Cart cart) {
        if (cart.Items.Count == 0) {
            Console.WriteLine("Cannot place order: Cart is empty.");
            return;
        }

        Console.WriteLine("\n=== Place Order ===");
        Console.WriteLine("Review your cart before placing order:");
        DisplayCartItems(cart);
        
        Console.Write("\nDo you want to place this order? (y/n): ");
        string? confirmation = Console.ReadLine()?.ToLower().Trim();
        
        if (confirmation == "y" || confirmation == "yes") {
            bool success = PlaceOrder(cart);
            if (success) {
                Console.WriteLine("\nOrder placed successfully! Your cart has been cleared.");
            }
        } else {
            Console.WriteLine("Order cancelled.");
        }
    }

    private bool IsProductExist(int productId, int qty = 0) {
        var product = products.FirstOrDefault(p => p.ProductId == productId);
        if (product == null) return false;

        // If no quantity requested, just check if product exists
        if (qty == 0) return true;
        
        // Check if requested quantity is available
        return product.Quantity >= qty;
    }

    private void DisplayCartItems(Cart cart) {
        Console.WriteLine($"{"Product ID",-12} {"Quantity",-10}");
        Console.WriteLine(new string('-', 22));
        foreach (var item in cart.Items) {
            Console.WriteLine($"{item.ProductId,-12} {item.Quantity,-10}");
        }
        Console.WriteLine($"\nTotal items: {cart.Items.Count}");
    }
}
