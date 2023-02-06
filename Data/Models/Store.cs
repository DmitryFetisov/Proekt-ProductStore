namespace ProductStore.Data.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        public string? TitleName { get; set; }

        public string? Adress { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Store()
        {
            Products = new List<Product>();
        }

    }
}
