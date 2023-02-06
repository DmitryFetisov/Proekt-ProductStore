using ProductStore.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductStore.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        Product getObjectProduct(int productId);
    }
}
