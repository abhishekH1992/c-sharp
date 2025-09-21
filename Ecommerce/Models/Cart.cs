public class Cart {
    public int CartId { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public bool IsCartOpen { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

public class CartItem {
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.Now;
}