using ProductStore.Data.Interfaces;
using ProductStore.Data.Models;

namespace ProductStore.Data.Repository
{
    public class StoreRepository : IProductsStore
    {

        private readonly AppDBContext appDbContent;
        public StoreRepository(AppDBContext appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Store> AllStores => appDbContent.Stores;
    }
}
