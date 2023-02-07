using Microsoft.EntityFrameworkCore;
using ProductStore.Data.Interfaces;
using ProductStore.Data.Models;


namespace ProductStore.Data.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly AppDBContext appDbContent;
        public ProductRepository(AppDBContext appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Product> Products => appDbContent.Products.Include(c => c.Stores);

        public Product getObjectProduct(int productId)
        {
            return appDbContent.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
