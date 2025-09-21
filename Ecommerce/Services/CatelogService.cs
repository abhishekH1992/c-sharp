public class CatelogService {

    private List<Category> categories;
    private List<Product> products;

    public CatelogService() {
        // Load data from seeders
        categories = CategorySeeder.CategoryData();
        products = ProductSeeder.ProductData();
    }

    public void ShowAllCategories() {
        Console.WriteLine("\n=== All Categories ===");
        Console.WriteLine($"{"ID",-5} {"Name",-20}");
        Console.WriteLine(new string('-', 25));
        
        for (int i = 0; i < categories.Count; i++) {
            Console.WriteLine($"{categories[i].CategoryId,-5} {categories[i].Name,-20}");
        }
        Console.WriteLine($"\nSelect by ID");
    }

    public void ShowAllProducts() {
        Console.WriteLine("\n=== All Products ===");
        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Category ID",-12}");
        Console.WriteLine(new string('-', 37));
        
        for (int i = 0; i < products.Count; i++) {
            Console.WriteLine($"{products[i].ProductId,-5} {products[i].Name,-20} {products[i].CategoryId,-12}");
        }
        Console.WriteLine($"\nSelect by ID");
    }

    public void ShowProductsByCategory(int categoryId) {
        // Find category name
        var category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
        string categoryName = category?.Name ?? "Unknown Category";
        
        // Filter products by category
        var filteredProducts = products.Where(p => p.CategoryId == categoryId).ToList();
        
        Console.WriteLine($"\n=== Products in {categoryName} (ID: {categoryId}) ===");
        
        if (filteredProducts.Count == 0) {
            Console.WriteLine("No products found in this category.");
            return;
        }
        
        Console.WriteLine($"{"ID",-5} {"Name",-20}");
        Console.WriteLine(new string('-', 25));
        
        foreach (var product in filteredProducts) {
            Console.WriteLine($"{product.ProductId,-5} {product.Name,-20}");
        }
        Console.WriteLine($"\nSelect by ID");
    }
}