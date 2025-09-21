public static class ProductSeeder {
    public static List<Product> ProductData() {
        return new List<Product> {
            new Product
            {
                ProductId = 1011,
                Name = "Monitor",
                CategoryId = 101,
                Quantity = 10
            },
            new Product
            {
                ProductId = 1012,
                Name = "Apple Mouse",
                CategoryId = 101,
                Quantity = 5
            },
            new Product
            {
                ProductId = 1013,
                Name = "Apple Keyboard",
                CategoryId = 101,
                Quantity = 5
            },
            new Product
            {
                ProductId = 1021,
                Name = "Jeans",
                CategoryId = 102,
                Quantity = 8
            },
            new Product
            {
                ProductId = 1022,
                Name = "T-shirt",
                CategoryId = 102,
                Quantity = 0
            },
            new Product
            {
                ProductId = 1023,
                Name = "Shirt",
                CategoryId = 102,
                Quantity = 2
            },
            new Product
            {
                ProductId = 1024,
                Name = "Shoes",
                CategoryId = 102,
                Quantity = 4
            },
            new Product
            {
                ProductId = 1031,
                Name = "Jeans",
                CategoryId = 103,
                Quantity = 1
            },
            new Product
            {
                ProductId = 1032,
                Name = "Jacket",
                CategoryId = 103,
                Quantity = 5
            },
            new Product
            {
                ProductId = 1033,
                Name = "T-shirt",
                CategoryId = 103,
                Quantity = 2
            },
            new Product
            {
                ProductId = 1034,
                Name = "Shirt",
                CategoryId = 103,
                Quantity = 2
            }
        };
    }
}