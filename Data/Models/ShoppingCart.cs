namespace ProductStore.Data.Models
{
    public class ShoppingCart
    {
        public int cartId { get; set; }
        public Product? Product { get; set; }

        public ushort Price { get; set; }

        public string? ShoppingCartId { get; set; }
    }
}
