
//Получение всех магазинов
using ProductStore.Data.Models;

namespace ProductStore.Data.Interfaces
{
    public interface IProductsStore
    {
        IEnumerable<Store> AllStores { get; }
    }
}
