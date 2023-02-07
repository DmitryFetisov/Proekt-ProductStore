namespace ProductStore.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? ProductsName { get; set; }

        public string? Desc { get; set; }  
        
        public ushort Price { get; set; }

        public bool Available { get; set; }

        
        public virtual ICollection<Store> Stores { get; set; }

        public Product()
        {
            Stores = new List<Store>();
        }
    }
}
