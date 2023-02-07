using Microsoft.AspNetCore.Cors.Infrastructure;
using ProductStore.Data.Models;

namespace ProductStore.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> allProducts { get; set; } = null!;
        public IEnumerable<Store> allStores { get; set; } = null!;
    }
}
