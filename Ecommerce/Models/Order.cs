public class Order {
    public int OrderId { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}