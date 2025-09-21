public class CartService {
    private List<Cart> carts = new List<Cart>();
    private List<Product> products;
    private int nextCartId = 1;

    public CartService() {
        products = ProductSeeder.ProductData();
    }

    public List<Cart> GetOpenCarts() {
        return carts.Where(c => c.IsCartOpen == true).ToList();
    }

    public Cart GetCurrentCart() {
        var openCart = carts.FirstOrDefault(c => c.IsCartOpen == true);
        if (openCart == null) {
            openCart = new Cart { CartId = nextCartId++, IsCartOpen = true };
            carts.Add(openCart);
        }
        return openCart;
    }

    public bool AddOrUpdateCartItem(int productId, int qty) {
        if(!IsProductExist(productId, qty)) return false;
        if (qty <= 0) return DeleteItemFromCart(productId);
        
        var cart = GetCurrentCart();
        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        
        if (existingItem != null) {
            // Update existing item quantity
            existingItem.Quantity = qty;
        } else {
            // Add new item to cart
            cart.Items.Add(new CartItem { ProductId = productId, Quantity = qty });
        }
        return true;
    }

    public bool DeleteItemFromCart(int productId) {
        if(!IsProductExist(productId, 0, true)) return false;
        var cart = GetCurrentCart();
        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        
        if (item != null) {
            cart.Items.Remove(item);
            return true;
        }
        return false;
    }

    public void CloseCart() {
        var cart = GetCurrentCart();
        cart.IsCartOpen = false;
    }

    // UI Methods - moved from Program.cs for better separation of concerns
    public void ShowCartMenu(CatelogService catelogService, OrderService orderService) {
        var cart = GetCurrentCart();
        
        Console.WriteLine("\n=== Your Cart ===");
        if (cart.Items.Count == 0) {
            Console.WriteLine("Your cart is empty.");
        } else {
            DisplayCartItems(cart);
        }
        
        Console.WriteLine("\nCart Options:");
        Console.WriteLine("1 - Add item to cart");
        Console.WriteLine("2 - Update item quantity");
        Console.WriteLine("3 - Remove item from cart");
        Console.WriteLine("4 - Place Order");
        Console.WriteLine("0 - Back to main menu");
        
        Console.Write("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out int choice)) {
            switch (choice) {
                case 1:
                    AddToCartUI(catelogService);
                    break;
                case 2:
                    UpdateCartItemUI();
                    break;
                case 3:
                    RemoveFromCartUI();
                    break;
                case 4:
                    orderService.PlaceOrderUI(cart);
                    break;
                case 0:
                    Console.WriteLine("Returning to main menu...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        } else {
            Console.WriteLine("Invalid input.");
        }
    }

    public void AddToCartUI(CatelogService catelogService) {
        Console.WriteLine("\n=== Add to Cart ===");
        catelogService.ShowAllProducts();
        
        Console.Write("\nEnter Product ID to add: ");
        if (int.TryParse(Console.ReadLine(), out int productId)) {
            Console.Write("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity)) {
                bool success = AddOrUpdateCartItem(productId, quantity);
                if (success) {
                    Console.WriteLine($"Successfully added Product {productId} (qty: {quantity}) to cart!");
                } else {
                    var product = products.FirstOrDefault(p => p.ProductId == productId);
                    if (product == null) {
                        Console.WriteLine($"Product {productId} does not exist.");
                    } else if (product.Quantity < quantity) {
                        Console.WriteLine($"Insufficient quantity! Available: {product.Quantity}, Requested: {quantity}");
                    } else {
                        Console.WriteLine("Failed to add item to cart.");
                    }
                }
            } else {
                Console.WriteLine("Invalid quantity.");
            }
        } else {
            Console.WriteLine("Invalid Product ID.");
        }
    }

    public void UpdateCartItemUI() {
        var cart = GetCurrentCart();
        
        if (cart.Items.Count == 0) {
            Console.WriteLine("Your cart is empty. Nothing to update.");
            return;
        }
        
        Console.WriteLine("\n=== Update Cart Item ===");
        DisplayCartItems(cart);
        
        Console.Write("\nEnter Product ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int productId)) {
            Console.Write("Enter new quantity: ");
            if (int.TryParse(Console.ReadLine(), out int newQuantity)) {
                bool success = AddOrUpdateCartItem(productId, newQuantity);
                if (success) {
                    if (newQuantity == 0) {
                        Console.WriteLine($"Product {productId} removed from cart.");
                    } else {
                        Console.WriteLine($"Product {productId} quantity updated to {newQuantity}.");
                    }
                } else {
                    var product = products.FirstOrDefault(p => p.ProductId == productId);
                    if (product == null) {
                        Console.WriteLine($"Product {productId} does not exist.");
                    } else if (product.Quantity < newQuantity) {
                        Console.WriteLine($"Insufficient quantity! Available: {product.Quantity}, Requested: {newQuantity}");
                    } else {
                        Console.WriteLine("Failed to update cart item.");
                    }
                }
            } else {
                Console.WriteLine("Invalid quantity.");
            }
        } else {
            Console.WriteLine("Invalid Product ID.");
        }
    }

    public void RemoveFromCartUI() {
        var cart = GetCurrentCart();
        
        if (cart.Items.Count == 0) {
            Console.WriteLine("Your cart is empty. Nothing to remove.");
            return;
        }
        
        Console.WriteLine("\n=== Remove from Cart ===");
        DisplayCartItems(cart);
        
        Console.Write("\nEnter Product ID to remove: ");
        if (int.TryParse(Console.ReadLine(), out int productId)) {
            bool success = DeleteItemFromCart(productId);
            if (success) {
                Console.WriteLine($"Product {productId} removed from cart.");
            } else {
                Console.WriteLine($"Product {productId} not found in cart.");
            }
        } else {
            Console.WriteLine("Invalid Product ID.");
        }
    }

    // Reusable helper method for displaying cart items
    private void DisplayCartItems(Cart cart) {
        Console.WriteLine($"{"Product ID",-12} {"Quantity",-10}");
        Console.WriteLine(new string('-', 22));
        foreach (var item in cart.Items) {
            Console.WriteLine($"{item.ProductId,-12} {item.Quantity,-10}");
        }
        Console.WriteLine($"\nTotal items: {cart.Items.Count}");
    }

    private bool IsProductExist(int productId, int qty = 0, bool isItemDelete = false) {
        var product = products.FirstOrDefault(p => p.ProductId == productId);
        if (product == null) return false;

        if (isItemDelete) return true;
        
        // If no quantity requested, just check if product exists
        if (qty == 0) return true;
        
        // Check if requested quantity is available
        return product.Quantity >= qty;
    }
}