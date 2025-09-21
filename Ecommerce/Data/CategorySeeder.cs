public static class CategorySeeder {
    public static List<Category> CategoryData() {
        return new List<Category> {
            new Category
            {
                CategoryId = 101,
                Name = "Electronics"
            },
            new Category
            {
                CategoryId = 102,
                Name = "Men's Fashion"
            },
            new Category
            {
                CategoryId = 103,
                Name = "Women's Fashion"
            }
        };
    }
}